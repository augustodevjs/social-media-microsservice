using SocialMedia.NewsFeed.Domain.Contracts;

namespace SocialMedia.NewsFeed.Domain.SeedWork;

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
