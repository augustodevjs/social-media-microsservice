using SocialMedia.Posts.Domain.Entities;
using SocialMedia.Posts.Domain.Contracts;

namespace SocialMedia.Posts.Domain.Events;

public class PostCreated : IEvent
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public DateTime? PublishedAt { get; private set; }
    public User User { get; set; }

    public PostCreated(
        Guid id, 
        User user,
        string content, 
        string title,
        DateTime? publishedAt
    )
    {
        Id = id;
        User = user;
        Title = title;
        Content = content;
        PublishedAt = publishedAt;
    }
}
