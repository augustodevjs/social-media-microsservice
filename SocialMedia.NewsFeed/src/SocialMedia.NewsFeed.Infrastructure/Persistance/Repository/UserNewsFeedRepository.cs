using Microsoft.EntityFrameworkCore;
using SocialMedia.NewsFeed.Domain.Entities;
using SocialMedia.NewsFeed.Domain.Contracts.Repositories;
using SocialMedia.NewsFeed.Infrastructure.Persistance.Context;
using SocialMedia.NewsFeed.Infrastructure.Persistance.Abstractions;

namespace SocialMedia.NewsFeed.Infrastructure.Persistance.Repository;

public class UserNewsFeedRepository : Repository<UserNewsfeed>, IUserNewsFeedRepository
{
    public UserNewsFeedRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void DeleteNewsFeedByUserId(List<UserNewsfeed> userNewsfeeds)
    {
         Context.UserNewsfeeds.RemoveRange(userNewsfeeds);
    }

    public async Task<List<UserNewsfeed>> GetNewsFeedByUserId(Guid userId)
    {
        return await Context.UserNewsfeeds
            .Where(x => x.UserId == userId).Include(x => x.Posts)
            .ToListAsync();
    }
}
