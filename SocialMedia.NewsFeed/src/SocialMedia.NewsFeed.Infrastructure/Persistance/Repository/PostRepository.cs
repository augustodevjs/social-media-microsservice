using SocialMedia.NewsFeed.Domain.Entities;
using SocialMedia.NewsFeed.Domain.Contracts.Repositories;
using SocialMedia.NewsFeed.Infrastructure.Persistance.Context;
using SocialMedia.NewsFeed.Infrastructure.Persistance.Abstractions;

namespace SocialMedia.NewsFeed.Infrastructure.Persistance.Repository;

public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(ApplicationDbContext context) : base(context)
    {
    }
}
