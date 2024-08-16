﻿namespace SocialMedia.Posts.API.Configuration;

public static class ControllersConfiguration
{
    public static IServiceCollection AddAndConfigureControllers(this IServiceCollection services)
    {
        //services.AddControllers(options => options.Filters.Add(typeof(ApiExceptionFilter)));
        services.AddDocumentation();

        return services;
    }

    private static void AddDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();
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