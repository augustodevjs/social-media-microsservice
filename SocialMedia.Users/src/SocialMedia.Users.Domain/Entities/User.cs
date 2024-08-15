using FluentValidation.Results;
using SocialMedia.Users.Domain.Enums;
using SocialMedia.Users.Domain.Events;
using SocialMedia.Users.Domain.SeedWork;
using SocialMedia.Users.Domain.Exceptions;
using SocialMedia.Users.Domain.Validators;
using SocialMedia.Users.Domain.ValueObjects;

namespace SocialMedia.Users.Domain.Entities;

public class User : AggregateRoot
{
    public string? Email { get; private set; }
    public string FullName { get; private set; }
    public string DisplayName { get; private set; }
    public string? Description { get; private set; }
    public string? Header { get; private set; }
    public DateTime BirthDate { get; private set; }
    public UserStatus Status { get; private set; }
    public ContactInfo? Contact { get; private set; }
    public LocationInfo? Location { get; private set; }

    public User(
        string email, 
        string fullName, 
        string displayName, 
        DateTime birthDate
    ) : base()
    {
        Email = email;
        FullName = fullName;
        BirthDate = birthDate;
        DisplayName = displayName;
        Status = UserStatus.Active;

        ValidateAndThrow();
        AddEvent(new UserCreated(Email, DisplayName));
    }

    public void Update(
        string header, 
        string displayName, 
        string description, 
        ContactInfo contact,
        LocationInfo location
    )
    {
        Header = header;
        Contact = contact;
        Location = location;
        DisplayName = displayName;
        Description = description;

        ValidateAndThrow();
    }

    public override bool Validate(out ValidationResult validationResult)
    {
        validationResult = new UserValidator().Validate(this);
        return validationResult.IsValid;
    }

    private void ValidateAndThrow()
    {
        if (!Validate(out var validationResult))
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            throw new EntityValidationException("User is invalid", errors);
        }
    }
}
