using SocialMedia.Posts.Application.ViewModels;
using SocialMedia.Posts.Application.InputModels;
using SocialMedia.Posts.Application.Contracts.Services;

namespace SocialMedia.Posts.Application.Services;

public class PostService : IPostService
{
    public Task<Guid> Create(CreatePostInputModel model)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<PostItemViewModel>> GetAll(Guid userId)
    {
        throw new NotImplementedException();
    }
}
