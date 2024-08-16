using SocialMedia.Users.Domain.Contracts;

namespace SocialMedia.Users.Domain.SeedWork;

public abstract class AggregateRoot : BaseEntity
{
    public List<IEvent> Events { get; private set; }

    protected AggregateRoot() : base()
    {
        Events = [];
    }
}
