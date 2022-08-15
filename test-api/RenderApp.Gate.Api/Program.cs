using RenderApp.GrpcClient;
using RenderApp.GrpcClient.Contracts.Responses;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddRenderAppGrpc(builder.Configuration, "apis:render");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/render/stream", async (IRenderAppService service, CancellationToken token) =>
{
    async IAsyncEnumerable<SomeDataResponse> GetStream()
    {
        await foreach (var item in service.GetSteam())
            yield return item;
    }
    

    return GetStream();
});

app.Run();