using Ocelot.Middleware;
using SocialMedia.APIGateway.Configuration;

namespace SocialMedia.APIGateway;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAndConfigureControllers();

        var app = builder.Build();

        app.UseDocumentation();
        await app.UseOcelot();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
