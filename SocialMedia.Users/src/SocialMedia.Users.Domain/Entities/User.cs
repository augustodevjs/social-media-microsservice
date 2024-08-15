using SocialMedia.Users.Domain.Enums;
using SocialMedia.Users.Domain.Events;
using SocialMedia.Users.Domain.SeedWork;
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

        Events.Add(new UserCreated(Email, DisplayName));
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
        DisplayName = displayName;
        Description = description;
        Contact = contact;
        Location = location;
    }
}
