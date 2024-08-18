using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Posts.Application.ViewModels;
using SocialMedia.Posts.Domain.Contracts.Repositories;

namespace SocialMedia.Posts.Application.Consumers;

public class UserDeletedConsumer : BackgroundService
{
    private readonly string _queue;
    private readonly IModel _channel;
    private readonly IServiceProvider _serviceProvider;

    public UserDeletedConsumer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        _queue = Environment.GetEnvironmentVariable("QUEUE_DELETED_USER_POST")!;

        var exchange = Environment.GetEnvironmentVariable("EXCHANGE_USER");
        var routingKey = Environment.GetEnvironmentVariable("ROUTING_KEY_DELETED_USER_POST");

        var connectionFactory = new ConnectionFactory
        {
            HostName = Environment.GetEnvironmentVariable("HOST_NAME")
        };

        var connection = connectionFactory.CreateConnection();

        _channel = connection.CreateModel();

        _channel.QueueDeclare(_queue, true, false, false, null);
        _channel.ExchangeDeclare(exchange, "direct", true, false);
        _channel.QueueBind(_queue, exchange, routingKey);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var contentArray = eventArgs.Body.ToArray();
            var json = Encoding.UTF8.GetString(contentArray);

            var @event = JsonConvert.DeserializeObject<UserDeletedEventViewModel>(json);

            await DeletePost(@event!);

            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };

        _channel.BasicConsume(_queue, false, consumer);

        return Task.CompletedTask;
    }

    private async Task DeletePost(UserDeletedEventViewModel @event)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var repository = scope.ServiceProvider
                .GetRequiredService<IPostRepository>();

            var posts = await repository.GetAllPostsByUserId(@event.Id);

            if (posts == null) return;

            foreach(var post in posts)
            {
                repository.Delete(post!);
            }

            await repository.UnityOfWork.Commit();
        }
    }
}
