using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RenderApp.DataAccess.Postgres;

public static class TypesRegistration
{
    public static IServiceCollection AddPostgresStore(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddDbContextPool<AppDbContext>(e => e.UseNpgsql(configuration.GetConnectionString("default")));
    }
}