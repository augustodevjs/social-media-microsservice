using MediatR;
using SocialMedia.Users.Application.Models;
using SocialMedia.Users.Domain.ValueObjects;

namespace SocialMedia.Users.Application.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<BaseResult>
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string Header { get; set; }
    public LocationInfoModel Location { get; set; }
    public ContactInfoModel Contact { get; set; }
}

public class LocationInfoModel
{
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public LocationInfo ToValueObject() => new(City, State, Country);
}

public class ContactInfoModel
{
    public string WebSite { get; set; }
    public string PhoneNumber { get; set; }

    public ContactInfo ToValueObject() => new(WebSite, PhoneNumber);
}
