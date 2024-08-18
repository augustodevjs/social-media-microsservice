namespace SocialMedia.NewsFeed.Domain.Entities;

public class Post
{
    public Guid Id { get; private set; }
    public string Content { get; private set; }
    public string Title { get; private set; }
    public DateTime PublishedAt { get; private set; }

    public Post(Guid id, string content, string title, DateTime publishedAt)
    {
        Id = id;
        Title = title;
        Content = content;
        PublishedAt = publishedAt;
    }
}
