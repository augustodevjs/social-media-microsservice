﻿using FluentValidation;
using SocialMedia.Posts.Domain.Entities;

namespace SocialMedia.Posts.Domain.Validators;

public class PostValidator : AbstractValidator<Post>
{
    public PostValidator()
    {
        RuleFor(post => post.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(post => post.Content)
            .NotEmpty()
            .WithMessage("Content is required.")
            .MaximumLength(280)
            .WithMessage("Content must be at most 280 characters long.");

        RuleFor(post => post.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(50)
            .WithMessage("Title must be at most 50 characters long.");

        RuleFor(post => post.User.Id)
            .NotEmpty()
            .WithMessage("User Id is required.");
    }
}
