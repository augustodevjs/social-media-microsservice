using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SocialMedia.NewsFeed.Domain.Contracts;

namespace SocialMedia.NewsFeed.Infrastructure.EventBus
{
    public class RabbitMQBus : IEventBus
    {
        private readonly IModel _channel;

        public RabbitMQBus()
        {
            var hostName = GetEnvironmentVariable("HOST_NAME");

            var factory = new ConnectionFactory
            {
                HostName = hostName
            };

            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
        }

        public void Publish<T>(T @event, string exchangeName, string routingKey, string queueName)
        {
            _channel.ExchangeDeclare(exchangeName, "direct", durable: true, autoDelete: false);
            _channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(queueName, exchangeName, routingKey);

            var json = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(exchangeName, routingKey, null, body);
        }

        private static string GetEnvironmentVariable(string variableName)
        {
            var value = Environment.GetEnvironmentVariable(variableName);

            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException($"Environment variable '{variableName}' is not set.");
            }

            return value;
        }
    }
}
