using SocialMedia.Posts.Application.Services;
using SocialMedia.Posts.Application.Consumers;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Posts.Application.Contracts.Services;

namespace SocialMedia.Posts.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddServices()
            .AddHostedService();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();

        return services;
    }

    private static void AddHostedService(this IServiceCollection services)
    {
        services.AddHostedService<UserDeletedConsumer>();
    }
}
