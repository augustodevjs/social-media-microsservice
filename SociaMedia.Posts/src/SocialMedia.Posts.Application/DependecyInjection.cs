using SocialMedia.Posts.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Posts.Application.Contracts.Services;

namespace SocialMedia.Posts.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddServices();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();

        return services;
    }
}
