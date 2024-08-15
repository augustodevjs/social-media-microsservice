using MediatR;
using SocialMedia.Users.Domain.Enums;
using SocialMedia.Users.Domain.Entities;

namespace SocialMedia.Users.Application.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<GetUserByIdViewModel>
{
    public Guid Id { get; private set; }

    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
}

public class GetUserByIdViewModel
{
    public Guid Id { get; private set; }
    public string? City { get; private set; }
    public string? State { get; private set; }
    public string? Email { get; private set; }
    public string? Header { get; private set; }
    public string FullName { get; private set; }
    public string? Website { get; private set; }
    public string? Country { get; private set; }
    public UserStatus Status { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? DisplayName { get; private set; }
    public string? Description { get; private set; }

    public GetUserByIdViewModel(User user)
    {
        Id = user.Id;
        Email = user.Email;
        Header = user.Header;
        Status = user.Status;
        FullName = user.FullName;
        BirthDate = user.BirthDate;
        City = user.Location?.City;
        State = user.Location?.State;
        DisplayName = user.DisplayName;
        Description = user.Description;
        Website = user.Contact?.Website;
        Country = user.Location?.Country;
        PhoneNumber = user.Contact?.PhoneNumber;
    }
} 