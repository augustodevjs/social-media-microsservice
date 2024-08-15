using SocialMedia.Posts.Application.InputModels;
using SocialMedia.Posts.Application.ViewModels;

namespace SocialMedia.Posts.Application.Contracts.Services;

public interface IPostService
{
    Task<BaseResult> Delete(Guid id);
    Task<BaseResult<Guid>> Create(CreatePostInputModel model);
    Task<BaseResult<List<PostItemViewModel>>> GetAll(Guid userId);
}