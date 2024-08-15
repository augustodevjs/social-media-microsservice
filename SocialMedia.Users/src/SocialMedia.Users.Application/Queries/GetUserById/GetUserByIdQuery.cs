using MediatR;
using SocialMedia.Users.Domain.Entities;
using SocialMedia.Users.Application.Models;

namespace SocialMedia.Users.Application.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<BaseResult<GetUserByIdViewModel>>
{
    public Guid Id { get; private set; }

    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
}

public class GetUserByIdViewModel
{
    public string? Header { get; private set; }
    public string? Website { get; private set; }
    public string? Country { get; private set; }
    public string? DisplayName { get; private set; }
    public string? Description { get; private set; }
    public DateTime BirthDate { get; private set; }

    public GetUserByIdViewModel(User user)
    {
        Header = user.Header;
        BirthDate = user.BirthDate;
        DisplayName = user.DisplayName;
        Website = user.Contact?.Website;
        Description = user.Description;
        Country = user.Location?.Country;
    }
} 