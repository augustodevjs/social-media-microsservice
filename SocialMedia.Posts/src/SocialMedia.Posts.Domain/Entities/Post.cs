using FluentValidation.Results;
using SocialMedia.Posts.Domain.Events;
using SocialMedia.Posts.Domain.SeedWork;
using SocialMedia.Posts.Domain.Exceptions;
using SocialMedia.Posts.Domain.Validators;

namespace SocialMedia.Posts.Domain.Entities;

public class Post : AggregateRoot
{
    public string Content { get; private set; }
    public User User { get; private set; }

    private Post()
    {

    }

    public Post(string content, User user) : base()
    {
        User = user;
        Content = content;

        ValidateAndThrow();

        AddEvent(new PostCreated(Id, User, Content, CreatedAt));
    }

    public override bool Validate(out ValidationResult validationResult)
    {
        validationResult = new PostValidator().Validate(this);
        return validationResult.IsValid;
    }

    private void ValidateAndThrow()
    {
        if (!Validate(out var validationResult))
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            throw new EntityValidationException("Post is invalid", errors);
        }
    }
}