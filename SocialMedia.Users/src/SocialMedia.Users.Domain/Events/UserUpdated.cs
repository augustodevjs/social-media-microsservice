using SocialMedia.Users.Domain.Contracts;

namespace SocialMedia.Users.Domain.Events;

public class UserUpdated : IEvent
{
    public Guid Id { get; private set; }
    public string DisplayName { get; private set; }

    public UserUpdated(Guid id, string displayName)
    {
        Id = id;
        DisplayName = displayName;
    }
}
