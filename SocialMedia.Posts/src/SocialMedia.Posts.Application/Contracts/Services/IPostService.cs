using SocialMedia.Posts.Application.ViewModels;
using SocialMedia.Posts.Application.InputModels;

namespace SocialMedia.Posts.Application.Contracts.Services;

public interface IPostService
{
    Task Delete(Guid id);
    Task Create(CreatePostInputModel model);
    Task<List<PostItemViewModel>> GetAll(Guid userId);
}