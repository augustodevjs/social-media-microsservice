using MediatR;
using SocialMedia.Users.Domain.Events;
using SocialMedia.Users.Domain.Contracts;
using SocialMedia.Users.Domain.Exceptions;
using SocialMedia.Users.Application.Exceptions;
using SocialMedia.Users.Domain.Contracts.Repositories;
using SocialMedia.Users.Application.Queries.GetUserById;

namespace SocialMedia.Users.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, GetUserByIdViewModel>
{
    private readonly IEventBus _bus;
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IEventBus bus, IUserRepository userRepository)
    {
        _bus = bus;
        _userRepository = userRepository;
    }

    public async Task<GetUserByIdViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userRepository.GetById(request.Id);

            if (user == null)
                NotFoundException.ThrowIfNull(user, "User not found");

            user!.Update(
                request.Header,
                request.DisplayName,
                request.Description,
                request.Contact.ToValueObject(),
                request.Location.ToValueObject()
           );

            _userRepository.Update(user);

            user!.Events.Add(new UserUpdated(user.Id, user.DisplayName));

            foreach (var @event in user.Events)
            {
                _bus.Publish(
                    @event,
                    Environment.GetEnvironmentVariable("EXCHANGE_USER")!,
                    Environment.GetEnvironmentVariable("ROUTING_KEY_UPDATED_USER")!,
                    Environment.GetEnvironmentVariable("QUEUE_UPDATED_USER")!
                );
            }

            await _userRepository.UnityOfWork.Commit();

            return new GetUserByIdViewModel(user);
        }
        catch (EntityValidationException ex)
        {
            throw new EntityValidationException(ex.Message, ex.Errors);
        }
    }
}
