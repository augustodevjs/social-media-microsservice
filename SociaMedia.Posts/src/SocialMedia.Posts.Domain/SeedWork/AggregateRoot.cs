using SocialMedia.Posts.Domain.Contracts;

namespace SocialMedia.Posts.Domain.SeedWork;

public abstract class AggregateRoot : BaseEntity
{
    public List<IEvent> Events { get; private set; }

    protected AggregateRoot() : base()
    {
        Events = [];
    }

    protected void AddEvent(IEvent @event)
    {
        Events.Add(@event);
    }
}
