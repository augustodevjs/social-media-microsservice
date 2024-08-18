using SocialMedia.Posts.Domain.Contracts;
using SocialMedia.Posts.Domain.Exceptions;
using SocialMedia.Posts.Application.ViewModels;
using SocialMedia.Posts.Application.Exceptions;
using SocialMedia.Posts.Application.InputModels;
using SocialMedia.Posts.Domain.Contracts.Repositories;
using SocialMedia.Posts.Application.Contracts.Services;
using SocialMedia.Posts.Domain.Entities;
using SocialMedia.Posts.Domain.Events;

namespace SocialMedia.Posts.Application.Services;

public class PostService : IPostService
{
    private readonly IEventBus _bus;
    private readonly IPostRepository _postRepository;

    public PostService(IEventBus bus, IPostRepository postRepository)
    {
        _bus = bus;
        _postRepository = postRepository;
    }

    public async Task Create(CreatePostInputModel model)
    {
        try
        {
            var post = model.ToEntity();

            _postRepository.Create(post);

            foreach (var @event in post.Events)
            {
                _bus.Publish(
                    @event,
                    Environment.GetEnvironmentVariable("EXCHANGE_POST")!,
                    Environment.GetEnvironmentVariable("ROUTING_KEY_CREATED_POST")!,
                    Environment.GetEnvironmentVariable("QUEUE_CREATED_POST")!
                );
            }

            await _postRepository.UnityOfWork.Commit();
        }
        catch (EntityValidationException ex)
        {
            throw new EntityValidationException(ex.Message, ex.Errors);
        }
    }

    public async Task Delete(Guid id)
    {
        var post = await _postRepository.GetById(id);

        if (post == null)
            NotFoundException.ThrowIfNull(post, "Post not found.");

        _postRepository.Delete(post!);

        post!.Events.Add(new PostDeleted(id));

        foreach (var @event in post.Events)
        {
            _bus.Publish(
                @event,
                Environment.GetEnvironmentVariable("EXCHANGE_POST")!,
                Environment.GetEnvironmentVariable("ROUTING_KEY_DELETED_POST")!,
                Environment.GetEnvironmentVariable("QUEUE_DELETED_POST")!
            );
        }

        await _postRepository.UnityOfWork.Commit();
    }

    public async Task<List<PostItemViewModel>> GetAll(Guid userId)
    {
        var posts = await _postRepository.GetAllPostsByUserId(userId);

        var viewModels = posts.Select(p => new PostItemViewModel(p)).ToList();

        return new List<PostItemViewModel>(viewModels);
    }
}
