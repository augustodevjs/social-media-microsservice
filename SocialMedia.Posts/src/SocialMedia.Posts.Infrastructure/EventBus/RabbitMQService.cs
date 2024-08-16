namespace SocialMedia.Posts.Infrastructure.EventBus;

public class RabbitMQService : IEventBus
{
    public void Publish<T>(T @event)
    {
        throw new NotImplementedException();
    }
}
