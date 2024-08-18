namespace SocialMedia.NewsFeed.Application.Exceptions;

public abstract class ApplicationException : Exception
{
    protected ApplicationException(string? message) : base(message)
    {
    }
}