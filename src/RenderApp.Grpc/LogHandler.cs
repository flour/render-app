using Microsoft.Extensions.Logging;

namespace RenderApp.Grpc;

public class LogHandler : DelegatingHandler
{
    private readonly Guid _meId = Guid.NewGuid();
    private readonly ILogger<LogHandler> _logger;

    public LogHandler(ILogger<LogHandler> logger)
    {
        _logger = logger;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handler: {Id}", _meId);
        return base.SendAsync(request, cancellationToken);
    }

    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handler: {Id}", _meId);
        return base.Send(request, cancellationToken);
    }
}