using SocialMedia.Posts.Domain.Entities;

namespace SocialMedia.Posts.Application.InputModels;

public class CreatePostInputModel
{
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public string Title { get; set; }

    public Post ToEntity() => new(Content, new User(UserId), Title);
}