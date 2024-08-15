using MediatR;
using SocialMedia.Users.Application.Models;
using SocialMedia.Users.Domain.Contracts.Repositories;

namespace SocialMedia.Users.Application.Commands.SignUpUser;

public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, BaseResult<Guid>>
{
    private readonly IUserRepository _userRepository;

    public SignUpUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResult<Guid>> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.ToEntity();

        _userRepository.Create(user);

        await _userRepository.UnityOfWork.Commit();

        return new BaseResult<Guid>(user.Id);
    }
}
