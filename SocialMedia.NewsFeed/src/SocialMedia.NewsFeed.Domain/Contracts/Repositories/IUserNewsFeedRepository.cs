using SocialMedia.NewsFeed.Domain.Entities;

namespace SocialMedia.NewsFeed.Domain.Contracts.Repositories;

public interface IUserNewsFeedRepository : IRepository<UserNewsfeed>
{
    Task<List<UserNewsfeed>> GetNewsFeedByUserId(Guid userId);
    void DeleteNewsFeedByUserId(List<UserNewsfeed> userNewsfeeds);
}
