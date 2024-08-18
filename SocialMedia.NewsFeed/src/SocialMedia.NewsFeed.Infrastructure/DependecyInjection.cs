using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialMedia.NewsFeed.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.NewsFeed.Infrastructure.EventBus;
using SocialMedia.NewsFeed.Domain.Contracts.Repositories;
using SocialMedia.NewsFeed.Infrastructure.Persistance.Context;
using SocialMedia.NewsFeed.Infrastructure.Persistance.Repository;

namespace SocialMedia.NewsFeed.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SocialMediaNewsFeed");

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
        services.AddScoped<IUserNewsFeedRepository, UserNewsFeedRepository>();

        return services;
    }

    private static IServiceCollection AddEventBus(this IServiceCollection services)
    {
        services.AddScoped<IEventBus, RabbitMQBus>();

        return services;
    }
}