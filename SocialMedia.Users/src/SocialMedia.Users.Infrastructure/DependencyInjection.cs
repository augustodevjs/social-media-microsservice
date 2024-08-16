using Microsoft.EntityFrameworkCore;
using SocialMedia.Users.Domain.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Users.Infrastructure.EventBus;
using SocialMedia.Users.Domain.Contracts.Repositories;
using SocialMedia.Users.Infrastructure.Persistance.Context;
using SocialMedia.Users.Infrastructure.Persistance.Repositories;

namespace SocialMedia.Users.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SocialMediaUser");

        services
            .AddEventBus()
            .AddRepositories()
            .AddDbContext(connectionString);

        return services;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, string? connectionString)
    {
        services
            .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }

    private static IServiceCollection AddEventBus(this IServiceCollection services)
    {
        services.AddScoped<IEventBus, RabbitMQBus>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
