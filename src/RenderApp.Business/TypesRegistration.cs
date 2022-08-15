using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RenderApp.DataAccess.Postgres;
using RenderApp.DataAccess.Redis;

namespace RenderApp.Business;

public static class TypesRegistration
{
    public static IServiceCollection AddBusiness(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddValidatorsFromAssembly(typeof(TypesRegistration).Assembly)
            .AddMediatR(typeof(TypesRegistration).Assembly)
            .AddPostgresStore(configuration)
            .AddRedisStore(configuration);
    }
}