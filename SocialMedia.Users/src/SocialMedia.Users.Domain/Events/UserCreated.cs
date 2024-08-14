using SocialMedia.Users.Domain.Contracts;

namespace SocialMedia.Users.Domain.Events;

public class UserCreated : IEvent
{
    public string Email { get; private set; }
    public string DisplayName { get; private set; }

    public UserCreated(string email, string displayName)
    {
        Email = email;
        DisplayName = displayName;
    }
}
