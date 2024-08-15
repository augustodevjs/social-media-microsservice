using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Users.Domain.Entities;
using SocialMedia.Users.Domain.Contracts;

namespace SocialMedia.Users.Infrastructure.Persistance.Context;

public class ApplicationDbContext : DbContext, IUnityOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

    public async Task<bool> Commit() => await SaveChangesAsync() > 0;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
