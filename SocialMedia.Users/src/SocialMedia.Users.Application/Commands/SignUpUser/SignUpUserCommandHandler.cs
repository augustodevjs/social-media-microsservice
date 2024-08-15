using MediatR;
using SocialMedia.Users.Domain.Exceptions;
using SocialMedia.Users.Domain.Contracts.Repositories;

namespace SocialMedia.Users.Application.Commands.SignUpUser;

public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand>
{
    private readonly IUserRepository _userRepository;

    public SignUpUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(SignUpUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = request.ToEntity();

            _userRepository.Create(user);

            await _userRepository.UnityOfWork.Commit();
        }
        catch (EntityValidationException ex)
        {
            throw new EntityValidationException(ex.Message, ex.Errors);
        }
    }
}
