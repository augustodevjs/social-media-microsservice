using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Posts.Domain.SeedWork;
using SocialMedia.Posts.Domain.Contracts;
using SocialMedia.Posts.Infrastructure.Persistance.Context;

namespace SocialMedia.Posts.Infrastructure.Persistance.Abstractions;
public abstract class Repository<T> : IRepository<T> where T : BaseEntity
{
    private bool _isDisposed;
    private readonly DbSet<T> _dbSet;
    protected readonly ApplicationDbContext Context;

    protected Repository(ApplicationDbContext context)
    {
        Context = context;
        _dbSet = context.Set<T>();
    }

    public IUnityOfWork UnityOfWork => Context;

    public async Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.AsNoTrackingWithIdentityResolution().Where(expression).FirstOrDefaultAsync();
    }

    public virtual async Task<List<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T?> GetById(Guid? id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual void Create(T entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed) return;

        if (disposing) Context.Dispose();

        _isDisposed = true;
    }
}