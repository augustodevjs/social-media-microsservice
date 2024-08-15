using MediatR;
using SocialMedia.Users.Application.Models;
using SocialMedia.Users.Domain.Contracts.Repositories;

namespace SocialMedia.Users.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseResult>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<BaseResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.Id);

        user.Update(
            request.Header, 
            request.DisplayName, 
            request.Description, 
            request.Contact.ToValueObject(),
            request.Location.ToValueObject()
       );

        _userRepository.Update(user);

        await _userRepository.UnityOfWork.Commit();

        return new BaseResult();
    }
}
