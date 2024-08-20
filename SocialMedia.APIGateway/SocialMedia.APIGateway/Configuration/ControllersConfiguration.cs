using Ocelot.DependencyInjection;

namespace SocialMedia.APIGateway.Configuration;

public static class ControllersConfiguration
{
    public static IServiceCollection AddAndConfigureControllers(this IServiceCollection services)
    {
        services
            .AddDocumentation()
            .AddApiGateway();

        return services;
    }

    private static IServiceCollection AddDocumentation(this IServiceCollection services)
    {
        services
            .AddSwaggerGen()
            .AddEndpointsApiExplorer();

        return services;
    }

    private static IServiceCollection AddApiGateway(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("ocelot.json")
            .Build();

        services.AddOcelot(configuration);
        services.AddSwaggerForOcelot(configuration);

        return services;
    }

    public static WebApplication UseDocumentation(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.PathToSwaggerGenerator = "/swagger/docs";
            });
        }

        return app;
    }
}
