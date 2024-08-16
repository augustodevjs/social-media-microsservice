namespace SocialMedia.Posts.Domain.Contracts;

public interface IEventBus
{
    void Publish<T>(T @event);
}
