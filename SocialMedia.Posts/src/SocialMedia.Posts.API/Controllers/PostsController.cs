using Microsoft.AspNetCore.Mvc;
using SocialMedia.Posts.Application.InputModels;
using SocialMedia.Posts.Application.Contracts.Services;

namespace SocialMedia.Posts.API.Controllers;

[ApiController]
[Route("api/users/{userId}/[controller]")]

public class PostsController : Controller
{
    //private readonly IPostService _service;

    //public PostsController(IPostService service)
    //{
    //    _service = service;
    //}

    //[HttpGet]
    //public async Task<IActionResult> Get(Guid userId)
    //{
    //    var result = await _service.GetAll(userId);

    //    return Ok(result);
    //}

    //[HttpPost]
    //public async Task<IActionResult> Post(Guid userId, [FromBody] CreatePostInputModel model)
    //{
    //    model.UserId = userId;

    //    var result = await _service.Create(model);

    //    return Ok(result);
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> Delete(Guid id)
    //{
    //    await _service.Delete(id);

    //    return Ok(result);
    //}
}
