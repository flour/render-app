using Microsoft.EntityFrameworkCore;
using RenderApp.DataAccess.Postgres;

namespace RenderApp.Api.Extensions;

internal static class StartupExtensions
{
    internal static IApplicationBuilder Migrate(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.Migrate();

        return builder;
    }
}