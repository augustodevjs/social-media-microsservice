namespace SocialMedia.NewsFeed.Domain.Contracts;

public interface IUnityOfWork
{
    Task<bool> Commit();
}