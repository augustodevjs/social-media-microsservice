using MediatR;

namespace SocialMedia.Users.Application.Commands.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public Guid Id { get; private set; }

    public DeleteUserCommand(Guid id)
    {
        Id = id;
    }
}
