using SocialMedia.Posts.Domain.Entities;

namespace SocialMedia.Posts.Application.ViewModels;

public class PostItemViewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; private set; }
    public string Content { get; private set; }
    public string UserDisplayName { get; private set; }

    public PostItemViewModel(Post post)
    {
        Id = post.Id;
        UserId = post.User.Id;
        Content = post.Content;
        UserDisplayName = post.User.DisplayName;
    }
}
