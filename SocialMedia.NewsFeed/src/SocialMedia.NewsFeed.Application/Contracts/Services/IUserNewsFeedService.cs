using SocialMedia.NewsFeed.Application.ViewModels;

namespace SocialMedia.NewsFeed.Application.Contracts.Services;

public interface IUserNewsFeedService
{
    Task<List<UserNewsFeedViewModel>> GetUserNewsFeedByUserId(Guid userId);
}
