using Microsoft.Extensions.DependencyInjection;
using SocialMedia.NewsFeed.Application.Services;
using SocialMedia.NewsFeed.Application.Consumers;
using SocialMedia.NewsFeed.Application.Contracts.Services;

namespace SocialMedia.NewsFeed.Application;

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
        services.AddScoped<IUserNewsFeedService, UserNewsFeedService>();

        return services;
    }


    private static IServiceCollection AddHostedService(this IServiceCollection services)
    {
        services
            .AddHostedService<PostCreatedEventConsumer>()
            .AddHostedService<PostDeletedEventConsumer>()
            .AddHostedService<UserDeletedEventConsumer>();

        return services;
    }
}
