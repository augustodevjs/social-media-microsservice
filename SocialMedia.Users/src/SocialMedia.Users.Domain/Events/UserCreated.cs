using SocialMedia.Users.Domain.Contracts;

namespace SocialMedia.Users.Domain.Events;

public class UserCreated : IEvent
{
    public Guid Id { get; private set; }
    public string DisplayName { get; private set; }

    public UserCreated(Guid id, string displayName)
    {
        Id = id;
        DisplayName = displayName;
    }
}
