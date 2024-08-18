using MediatR;
using SocialMedia.Users.Domain.Events;
using SocialMedia.Users.Domain.Contracts;
using SocialMedia.Users.Application.Exceptions;
using SocialMedia.Users.Domain.Contracts.Repositories;

namespace SocialMedia.Users.Application.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IEventBus _bus;
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IEventBus bus, IUserRepository userRepository)
    {
        _bus = bus;
        _userRepository = userRepository;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.Id);

        if (user == null)
            NotFoundException.ThrowIfNull(user, "User not found.");

        _userRepository.Delete(user!);

        user!.Events.Add(new UserDeleted(user.Id));

        foreach (var @event in user.Events)
        {
            _bus.Publish(
                @event, 
                Environment.GetEnvironmentVariable("EXCHANGE_USER")!,
                Environment.GetEnvironmentVariable("ROUTING_KEY_DELETED_USER_POST")!,
                Environment.GetEnvironmentVariable("QUEUE_DELETED_USER_POST")!
            );

            _bus.Publish(
                @event,
                Environment.GetEnvironmentVariable("EXCHANGE_USER")!,
                Environment.GetEnvironmentVariable("ROUTING_KEY_DELETED_USER_NEWSFEED")!,
                Environment.GetEnvironmentVariable("QUEUE_DELETED_USER_NEWSFEED")!
            );
        }

        await _userRepository.UnityOfWork.Commit();
    }
}
