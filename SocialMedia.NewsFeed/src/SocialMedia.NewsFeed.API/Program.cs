using SocialMedia.NewsFeed.Application;
using SocialMedia.NewsFeed.Infrastructure;
using SocialMedia.NewsFeed.API.Configuration;

namespace SocialMedia.NewsFeed.API;

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
