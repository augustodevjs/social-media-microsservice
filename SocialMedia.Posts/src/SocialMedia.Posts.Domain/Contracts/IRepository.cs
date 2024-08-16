using System.Linq.Expressions;
using SocialMedia.Posts.Domain.SeedWork;

namespace SocialMedia.Posts.Domain.Contracts;

public interface IRepository<T> : IDisposable where T : BaseEntity
{
    public IUnityOfWork UnityOfWork { get; }

    public Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression);
    void Create(T entity);
    Task<T?> GetById(Guid? id);
    Task<List<T>> GetAll();
    void Update(T entity);
    void Delete(T entity);
}