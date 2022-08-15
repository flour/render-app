using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Client;
using ProtoBuf.Grpc.ClientFactory;

namespace RenderApp.Grpc;

public static class DependencyInjection
{
    public static IServiceCollection AddGRpcService<T>(
        this IServiceCollection services,
        IConfiguration configuration,
        string sectionName) where T : class
    {
        GrpcClientFactory.AllowUnencryptedHttp2 = true;
        var serviceUrl = configuration.GetValue<string>(sectionName);
        return services
            .AddCodeFirstGrpcClient<T>(opts =>
            {
                opts.Address = new Uri(serviceUrl);
                opts.ChannelOptionsActions.Add(channelOpts =>
                {
                    channelOpts.HttpHandler = new SocketsHttpHandler
                    {
                        KeepAlivePingDelay = TimeSpan.FromSeconds(60),
                        KeepAlivePingTimeout = TimeSpan.FromSeconds(30),
                        PooledConnectionIdleTimeout = TimeSpan.FromSeconds(30),
                        EnableMultipleHttp2Connections = true
                    };
                });
            }).Services;
    }
}