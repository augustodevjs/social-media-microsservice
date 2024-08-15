using MediatR;
using SocialMedia.Users.Application.Exceptions;
using SocialMedia.Users.Domain.Contracts.Repositories;

namespace SocialMedia.Users.Application.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.Id);

        if (user == null)
            NotFoundException.ThrowIfNull(user, "User not found.");

        _userRepository.Delete(user!);

        await _userRepository.UnityOfWork.Commit();
    }
}
