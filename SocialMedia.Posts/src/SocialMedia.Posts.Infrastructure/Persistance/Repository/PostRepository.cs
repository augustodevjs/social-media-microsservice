using SocialMedia.Posts.Domain.Entities;
using SocialMedia.Posts.Domain.Contracts.Repositories;
using SocialMedia.Posts.Infrastructure.Persistance.Context;
using SocialMedia.Posts.Infrastructure.Persistance.Abstractions;

namespace SocialMedia.Posts.Infrastructure.Persistance.Repository;

public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(ApplicationDbContext context) : base(context)
    {
        
    }
}
