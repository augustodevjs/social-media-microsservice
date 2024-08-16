using SocialMedia.Posts.Application;
using SocialMedia.Posts.Infrastructure;
using SocialMedia.Posts.API.Configuration;

namespace SocialMedia.Posts.API;

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
