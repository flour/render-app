using Flour.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseLogging();

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();