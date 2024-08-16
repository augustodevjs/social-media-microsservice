using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SocialMedia.Posts.Domain.Contracts;

namespace SocialMedia.Posts.Infrastructure.EventBus
{
    public class RabbitMQBus : IEventBus
    {
        private readonly IModel _channel;
        private readonly string _exchangeName;
        private readonly string _routingKey;

        public RabbitMQBus()
        {
            var hostName = GetEnvironmentVariable("HOST_NAME");
            var queueName = GetEnvironmentVariable("QUEUE_NAME");

            _exchangeName = GetEnvironmentVariable("EXCHANGE_NAME");
            _routingKey = GetEnvironmentVariable("ROUTING_KEY");

            var factory = new ConnectionFactory
            {
                HostName = hostName
            };

            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.ExchangeDeclare(_exchangeName, "direct", durable: true, autoDelete: false);
            _channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(queueName, _exchangeName, _routingKey);
        }

        public void Publish<T>(T @event)
        {
            var json = JsonConvert.SerializeObject(@event);
            var body = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(_exchangeName, _routingKey, null, body);
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
