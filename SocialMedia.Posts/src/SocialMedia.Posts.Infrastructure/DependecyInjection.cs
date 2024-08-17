using Microsoft.EntityFrameworkCore;
using SocialMedia.Posts.Domain.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Posts.Infrastructure.EventBus;
using SocialMedia.Posts.Domain.Contracts.Repositories;
using SocialMedia.Posts.Infrastructure.Persistance.Context;
using SocialMedia.Posts.Infrastructure.Persistance.Repository;

namespace SocialMedia.Posts.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SocialMediaPost");

        services
            .AddEventBus()
            .AddRepositories()
            .AddDbContext(connectionString);

        return services;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>();

        return services;
    }

    private static IServiceCollection AddEventBus(this IServiceCollection services)
    {
        services.AddScoped<IEventBus, RabbitMQBus>();

        return services;
    }
}