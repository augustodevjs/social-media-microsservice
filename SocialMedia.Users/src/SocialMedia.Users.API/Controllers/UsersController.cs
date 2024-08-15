using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Users.Application.Commands.DeleteUser;
using SocialMedia.Users.Application.Commands.SignUpUser;
using SocialMedia.Users.Application.Commands.UpdateUser;
using SocialMedia.Users.Application.Queries.GetUserById;

namespace SocialMedia.Users.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetUserByIdViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(id);

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var query = new DeleteUserCommand(id);

        await _mediator.Send(query, cancellationToken);

        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(SignUpUserCommand command, CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(GetUserByIdViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
