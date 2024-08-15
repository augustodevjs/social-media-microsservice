using SocialMedia.Posts.Application.ViewModels;
using SocialMedia.Posts.Application.InputModels;
using SocialMedia.Posts.Application.Contracts.Services;

namespace SocialMedia.Posts.Application.Services;

public class PostService : IPostService
{
    public Task<BaseResult<Guid>> Create(CreatePostInputModel model)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResult> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<BaseResult<List<PostItemViewModel>>> GetAll(Guid userId)
    {
        throw new NotImplementedException();
    }
}
