namespace SocialMedia.Posts.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string DisplayName { get; private set; }

    public User(Guid id, string displayName)
    {
        Id = id;
        DisplayName = displayName;
    }
}
