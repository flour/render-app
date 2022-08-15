using Flour.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RenderApp.DataAccess.Redis.Internals;

namespace RenderApp.DataAccess.Redis;

public static class TypesRegistration
{
    public static IServiceCollection AddRedisStore(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddRedis(configuration)
            .AddScoped<IRedisUnit, RedisUnit>();
    }
}