using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.NewsFeed.Application.ViewModels;
using SocialMedia.NewsFeed.Domain.Contracts.Repositories;

namespace SocialMedia.NewsFeed.Application.Consumers;

public class UserDeletedEventConsumer : BackgroundService
{
    private readonly string _queue;
    private readonly IModel _channel;
    private readonly IServiceProvider _serviceProvider;

    public UserDeletedEventConsumer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        _queue = Environment.GetEnvironmentVariable("QUEUE_DELETED_USER")!;

        var exchange = Environment.GetEnvironmentVariable("EXCHANGE_USER");
        var routingKey = Environment.GetEnvironmentVariable("ROUTING_KEY_DELETED_USER");

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

            await DeleteUser(@event!);

            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };

        _channel.BasicConsume(_queue, false, consumer);

        return Task.CompletedTask;
    }

    private async Task DeleteUser(UserDeletedEventViewModel viewModel)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var repository = scope.ServiceProvider
                .GetRequiredService<IUserNewsFeedRepository>();

            var feeds = await repository.GetNewsFeedByUserId(viewModel.Id);

            if (feeds == null) return;

            repository.DeleteNewsFeedByUserId(feeds);

            await repository.UnityOfWork.Commit();
        }
    }
}
