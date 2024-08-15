using FluentValidation;
using SocialMedia.Users.Domain.Entities;

namespace SocialMedia.Users.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Id)
                .NotEmpty()
                .WithMessage("Id is required.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(user => user.FullName)
                .NotEmpty().WithMessage("Full name is required.")
                .MaximumLength(100).WithMessage("Full name must not exceed 100 characters.");

            RuleFor(user => user.DisplayName)
                .NotEmpty().WithMessage("Display name is required.")
                .MaximumLength(50).WithMessage("Display name must not exceed 50 characters.");

            RuleFor(user => user.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(user => user.Header)
                .MaximumLength(200).WithMessage("Header must not exceed 200 characters.");

            RuleFor(user => user.BirthDate)
                .NotEmpty().WithMessage("Birthdate is required.")
                .LessThan(DateTime.Now).WithMessage("Birthdate must be in the past.");

            RuleFor(user => user.Status)
                .IsInEnum().WithMessage("Invalid status value.");
        }
    }
}
