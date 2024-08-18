using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SocialMedia.NewsFeed.Domain.Entities;
using SocialMedia.NewsFeed.Domain.Contracts;

namespace SocialMedia.NewsFeed.Infrastructure.Persistance.Context;
public class ApplicationDbContext : DbContext, IUnityOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<UserNewsfeed> UserNewsfeeds { get; set; }

    public async Task<bool> Commit() => await SaveChangesAsync() > 0;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}