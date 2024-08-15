using MediatR;
using SocialMedia.Users.Application.Exceptions;
using SocialMedia.Users.Domain.Contracts.Repositories;

namespace SocialMedia.Users.Application.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdViewModel>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserByIdViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.Id);

        if (user == null)
            NotFoundException.ThrowIfNull(user, "User not found.");

        var userViewModel = new GetUserByIdViewModel(user);

        return userViewModel;
    }
}
