using Microsoft.AspNetCore.Mvc;
using SocialMedia.Posts.Application.ViewModels;
using SocialMedia.Posts.Application.InputModels;
using SocialMedia.Posts.Application.Contracts.Services;

namespace SocialMedia.Posts.API.Controllers;

[ApiController]
[Route("api/users/{userId}/[controller]")]

public class PostsController : Controller
{
    private readonly IPostService _service;

    public PostsController(IPostService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<PostItemViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> GetAll(Guid userId)
    {
        var result = await _service.GetAll(userId);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] CreatePostInputModel model)
    {
        await _service.Create(model);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.Delete(id);

        return NoContent();
    }
}
