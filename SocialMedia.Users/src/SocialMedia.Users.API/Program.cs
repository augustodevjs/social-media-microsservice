using SocialMedia.Users.Application;
using SocialMedia.Users.Infrastructure;
using SocialMedia.Users.API.Configuration;

namespace SocialMedia.Users.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddApplication()
            .AddAndConfigureControllers()
            .AddInfrastructure(builder.Configuration);

        var app = builder.Build();

        app.UseDocumentation();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
