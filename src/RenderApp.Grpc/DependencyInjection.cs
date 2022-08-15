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
            .AddScoped<LogHandler>()
            .AddHttpClient()
            .AddCodeFirstGrpcClient<T>(opts =>
            {
                opts.Address = new Uri(serviceUrl);
                opts.ChannelOptionsActions.Add(channelOpts =>
                {
                    channelOpts.DisposeHttpClient = true;
                    channelOpts.MaxRetryAttempts = 2;
                });
            }).AddHttpMessageHandler<LogHandler>().Services;
    }
}