using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RenderApp.Grpc;

namespace RenderApp.GrpcClient;

public static class TypesRegistration
{
    public static IServiceCollection AddRenderAppGrpc(
        this IServiceCollection services,
        IConfiguration configuration,
        string sectionName)
    {
        return services.AddGRpcService<IRenderAppService>(configuration, sectionName);
    }
}