using Microsoft.AspNetCore.Mvc;
using SocialMedia.NewsFeed.Application.ViewModels;
using SocialMedia.NewsFeed.Application.Contracts.Services;

namespace SocialMedia.NewsFeed.API.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsFeedController : ControllerBase
{
    private readonly IUserNewsFeedService _service;

    public NewsFeedController(IUserNewsFeedService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<UserNewsFeedViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> GetNewsFeedByUserId(Guid userId)
    {
        var result = await _service.GetUserNewsFeedByUserId(userId);

        return Ok(result);
    }
}
