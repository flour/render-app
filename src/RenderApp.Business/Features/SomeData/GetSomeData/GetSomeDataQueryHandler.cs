using MediatR;
using Microsoft.Extensions.Logging;
using RenderApp.Business.Features.SomeData.Models;
using RenderApp.Commons;

namespace RenderApp.Business.Features.SomeData.GetSomeData;

public class GetSomeDataQueryHandler : IRequestHandler<GetSomeDataQuery, PagedResult<SomeDataDto>>
{
    private readonly ILogger<GetSomeDataQueryHandler> _logger;

    public GetSomeDataQueryHandler(ILogger<GetSomeDataQueryHandler> logger)
    {
        _logger = logger;
    }
    
    public async Task<PagedResult<SomeDataDto>> Handle(GetSomeDataQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}