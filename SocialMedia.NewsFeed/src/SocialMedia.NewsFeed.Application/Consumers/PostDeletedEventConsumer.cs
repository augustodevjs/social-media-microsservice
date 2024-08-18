using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.NewsFeed.Application.ViewModels;
using SocialMedia.NewsFeed.Domain.Contracts.Repositories;

namespace SocialMedia.NewsFeed.Application.Consumers;

public class PostDeletedEventConsumer : BackgroundService
{
    private readonly string _queue;
    private readonly IModel _channel;
    private readonly IServiceProvider _serviceProvider;

    public PostDeletedEventConsumer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        _queue = Environment.GetEnvironmentVariable("QUEUE_DELETED_POST")!;

        var exchange = Environment.GetEnvironmentVariable("EXCHANGE_POST");
        var routingKey = Environment.GetEnvironmentVariable("ROUTING_KEY_DELETED_POST");

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

            var @event = JsonConvert.DeserializeObject<PostDeletedEventViewModel>(json);

            await DeletePost(@event!);

            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };

        _channel.BasicConsume(_queue, false, consumer);

        return Task.CompletedTask;
    }

    private async Task DeletePost(PostDeletedEventViewModel viewModel)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var repository = scope.ServiceProvider
                .GetRequiredService<IUserNewsFeedRepository>();

            var feed = await repository.GetById(viewModel.Id);

            if (feed == null) return; 

            repository.Delete(feed);

            await repository.UnityOfWork.Commit();
        }
    }
}
