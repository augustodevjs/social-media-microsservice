namespace SocialMedia.Posts.Domain.Contracts;

public interface IUnityOfWork
{
    Task<bool> Commit();
}