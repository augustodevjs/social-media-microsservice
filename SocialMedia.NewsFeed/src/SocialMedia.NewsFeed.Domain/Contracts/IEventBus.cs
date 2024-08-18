namespace SocialMedia.NewsFeed.Domain.Contracts;

public interface IEventBus
{
    void Publish<T>(T @event, string exchangeName, string routingKey, string queueName);
}
