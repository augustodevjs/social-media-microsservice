using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialMedia.Users.Domain.Exceptions;
using SocialMedia.Users.Application.Exceptions;

namespace SocialMedia.Users.API.Filter;

public class ApiExceptionFilter : IExceptionFilter
{
    private readonly IHostEnvironment _env;

    public ApiExceptionFilter(IHostEnvironment env)
    {
        _env = env;
    }

    public void OnException(ExceptionContext context)
    {
        var details = new ProblemDetails();
        var exception = context.Exception;

        if (_env.IsDevelopment())
        {
            details.Extensions.Add("StackTrace", exception.StackTrace);
        }

        if (exception is EntityValidationException validationException)
        {
            details.Title = "One or more validation errors occurred";
            details.Status = StatusCodes.Status422UnprocessableEntity;
            details.Type = "UnprocessableEntity";
            details.Detail = validationException.Message;
            details.Extensions.Add("Errors", validationException.Errors);
        }
        else if (exception is NotFoundException)
        {
            details.Title = "Not Found";
            details.Status = StatusCodes.Status404NotFound;
            details.Type = "NotFound";
            details.Detail = exception.Message;
        }
        else
        {
            details.Title = "An unexpected error occurred";
            details.Status = StatusCodes.Status500InternalServerError;
            details.Type = "UnexpectedError";
            details.Detail = exception.Message;
        }

        context.ExceptionHandled = true;
        context.Result = new ObjectResult(details);
        context.HttpContext.Response.StatusCode = (int)details.Status;
    }
}
