namespace SocialMedia.Users.Domain.Contracts;

public interface IUnityOfWork
{
    Task<bool> Commit();
}