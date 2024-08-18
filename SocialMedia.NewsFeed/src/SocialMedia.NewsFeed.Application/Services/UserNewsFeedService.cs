using SocialMedia.NewsFeed.Application.ViewModels;
using SocialMedia.NewsFeed.Application.Exceptions;
using SocialMedia.NewsFeed.Domain.Contracts.Repositories;
using SocialMedia.NewsFeed.Application.Contracts.Services;

namespace SocialMedia.NewsFeed.Application.Services;

public class UserNewsFeedService : IUserNewsFeedService
{
    private readonly IUserNewsFeedRepository _userNewsFeedRepository;

    public UserNewsFeedService(IUserNewsFeedRepository userNewsFeedRepository)
    {
        _userNewsFeedRepository = userNewsFeedRepository;
    }

    public async Task<List<UserNewsFeedViewModel>> GetUserNewsFeedByUserId(Guid userId)
    {
        var feeds = await _userNewsFeedRepository.GetNewsFeedByUserId(userId);

        if (feeds == null)
            NotFoundException.ThrowIfNull(feeds, "Feeds not found.");

        var userNewsFeedViewModels = feeds.Select(feed => new UserNewsFeedViewModel
        {
            Id = feed.Id,
            Posts = feed.Posts.Select(
                p => new PostsVieModel()
                {
                    Content = p.Content,
                    PublishedAt = p.PublishedAt,
                    Title = p.Title
                }).ToList()
        }).ToList();

        return userNewsFeedViewModels;
    }
}
