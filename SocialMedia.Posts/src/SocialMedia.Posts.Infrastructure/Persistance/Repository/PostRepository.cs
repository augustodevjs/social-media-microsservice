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

    public async Task<List<Post>> GetAllPostsByUserId(Guid id)
    {
        var posts = Context.Posts.Where(p => p.User.Id == id && !p.IsDeleted).ToList();

        return posts;
    }
}
