using SocialMedia.Posts.API.Filter;
using SocialMedia.Posts.Application.Consumers;

namespace SocialMedia.Posts.API.Configuration;

public static class ControllersConfiguration
{
    public static IServiceCollection AddAndConfigureControllers(this IServiceCollection services)
    {
        services.AddDocumentation();
        services.AddHostedService();
        services.AddControllers(options => options.Filters.Add(typeof(ApiExceptionFilter)));

        return services;
    }

    private static void AddDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();
    }

    private static void AddHostedService(this IServiceCollection services)
    {
        services.AddHostedService<UserDeletedConsumer>();
    }

    public static WebApplication UseDocumentation(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }
}