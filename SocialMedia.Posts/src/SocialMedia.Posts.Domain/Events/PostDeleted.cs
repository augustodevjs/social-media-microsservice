using SocialMedia.Posts.Domain.Contracts;

namespace SocialMedia.Posts.Domain.Events;

public class PostDeleted : IEvent
{
    public Guid Id { get; private set; }

    public PostDeleted(Guid id)
    {
        Id = id;
    }
}
