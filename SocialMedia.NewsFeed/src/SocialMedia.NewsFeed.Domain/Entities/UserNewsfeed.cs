using SocialMedia.NewsFeed.Domain.SeedWork;

namespace SocialMedia.NewsFeed.Domain.Entities;

public class UserNewsfeed : AggregateRoot
{
    public Guid UserId { get; private set; }
    public List<Post> Posts { get; private set; }

    public UserNewsfeed()
    {
    }

    public UserNewsfeed(Guid userId, List<Post> posts)
    {
        Posts = posts;
        UserId = userId;
    }
}
