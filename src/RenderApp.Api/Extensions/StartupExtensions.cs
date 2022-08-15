using Microsoft.EntityFrameworkCore;
using RenderApp.DataAccess.Postgres;

namespace RenderApp.Api.Extensions;

internal static class StartupExtensions
{
    internal static IApplicationBuilder Migrate(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        try
        {
            context.Database.Migrate();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Migration failed");
        }

        return builder;
    }
}