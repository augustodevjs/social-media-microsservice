using MediatR;
using SocialMedia.Users.Domain.Exceptions;
using SocialMedia.Users.Application.Exceptions;
using SocialMedia.Users.Domain.Contracts.Repositories;
using SocialMedia.Users.Application.Queries.GetUserById;

namespace SocialMedia.Users.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, GetUserByIdViewModel>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
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

            await _userRepository.UnityOfWork.Commit();

            return new GetUserByIdViewModel(user);
        }
        catch (EntityValidationException ex)
        {
            throw new EntityValidationException(ex.Message, ex.Errors);
        }
    }
}
