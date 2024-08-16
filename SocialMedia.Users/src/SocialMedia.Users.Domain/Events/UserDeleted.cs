using SocialMedia.Users.Domain.Contracts;

namespace SocialMedia.Users.Domain.Events;

public class UserDeleted : IEvent
{
    public Guid Id { get; private set; }

    public UserDeleted(Guid id)
    {
        Id = id;
    }
}
