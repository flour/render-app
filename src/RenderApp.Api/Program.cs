using Flour.Logging;
using ProtoBuf.Grpc.Server;
using RenderApp.Api.Extensions;
using RenderApp.Api.Services;
using RenderApp.Business;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseLogging();

// Add services to the container.
builder.Services
    .AddControllers().Services
    .AddBusiness(builder.Configuration)
    .AddCodeFirstGrpcReflection()
    .AddCodeFirstGrpc();

// Build app
var app = builder.Build();
app.Migrate();
app.UseRouting();
app.UseEndpoints(e =>
{
    e.MapControllers();
    e.MapGrpcService<RenderAppService>();
    e.MapCodeFirstGrpcReflectionService();
});

app.Run();