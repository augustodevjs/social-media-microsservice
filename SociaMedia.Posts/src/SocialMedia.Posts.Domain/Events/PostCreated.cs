using SocialMedia.Posts.Domain.Contracts;
using SocialMedia.Posts.Domain.Entities;

namespace SocialMedia.Posts.Domain.Events;

public class PostCreated : IEvent
{
    public Guid Id { get; private set; }
    public string Content { get; private set; }
    public DateTime? PublishedAt { get; private set; }
    public User User { get; set; }

    public PostCreated(
        Guid id, 
        User user,
        string content, 
        DateTime? publishedAt
    )
    {
        Id = id;
        User = user;
        Content = content;
        PublishedAt = publishedAt;
    }
}
