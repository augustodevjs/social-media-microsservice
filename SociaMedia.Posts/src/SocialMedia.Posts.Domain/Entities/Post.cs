using SocialMedia.Posts.Domain.Events;
using SocialMedia.Posts.Domain.SeedWork;

namespace SocialMedia.Posts.Domain.Entities;

public class Post : AggregateRoot
{
    public string Content { get; private set; }
    public User User { get; set; }

    public Post(string content, User user) : base()
    {
        Content = content;
        User = user;

        AddEvent(new PostCreated(Id, User, Content, CreatedAt));
    }
}