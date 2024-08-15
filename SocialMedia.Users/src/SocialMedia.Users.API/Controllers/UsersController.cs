using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetUserByIdQuery(id);

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(SignUpUserCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateUserCommand command)
    {
        command.Id = id;

        var result = await _mediator.Send(command);

        return Ok(result);
    }
}
