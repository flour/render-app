using System.Runtime.CompilerServices;
using MediatR;
using Microsoft.Extensions.Logging;
using RenderApp.Business.Features.SomeData.Models;

namespace RenderApp.Business.Features.SomeData.StreamData;

public class StreamDataQueryHandler : IStreamRequestHandler<StreamDataQuery, SomeDataDto>
{
    private readonly ILogger<StreamDataQueryHandler> _logger;

    public StreamDataQueryHandler(ILogger<StreamDataQueryHandler> logger)
    {
        _logger = logger;
    }

    public async IAsyncEnumerable<SomeDataDto> Handle(
        StreamDataQuery request,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var rnd = new Random();
        for (var i = 0; i < rnd.Next(1, 100); i++)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1), cancellationToken);
            yield return new SomeDataDto
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = $"Name {i:00000}",
                DecimalValue = (decimal) rnd.NextDouble(),
                IntValue = rnd.Next(1, 1000),
                DateTimeValue = DateTime.UtcNow
            };
        }
    }
}