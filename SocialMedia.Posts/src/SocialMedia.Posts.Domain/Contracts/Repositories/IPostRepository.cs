using SocialMedia.Posts.Domain.Entities;

namespace SocialMedia.Posts.Domain.Contracts.Repositories;

public interface IPostRepository : IRepository<Post>
{
    Task<List<Post>> GetAllPostsByUserId(Guid id);
}
