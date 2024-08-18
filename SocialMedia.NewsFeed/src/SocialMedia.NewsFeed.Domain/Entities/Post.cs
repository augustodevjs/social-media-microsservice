using SocialMedia.NewsFeed.Domain.SeedWork;

namespace SocialMedia.NewsFeed.Domain.Entities;

public class Post : BaseEntity
{
    public Guid UserId { get; private set; }
    public Guid PostId { get; private set; }
    public string Content { get; private set; }
    public string Title { get; private set; }
    public DateTime PublishedAt { get; private set; }

    public Post(Guid userId, Guid postId, string content, string title, DateTime publishedAt)
    {
        Title = title;
        UserId = userId;
        PostId = postId;
        Content = content;
        PublishedAt = publishedAt;
    }
}
