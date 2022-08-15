using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using RenderApp.Business.Features.SomeData.Models;
using RenderApp.Commons;
using RenderApp.DataAccess.Postgres;

namespace RenderApp.Business.Features.SomeData.GetSomeData;

public class GetSomeDataQueryHandler : IRequestHandler<GetSomeDataQuery, PagedResult<SomeDataDto>>
{
    private readonly IUnitOfWork _unit;
    private readonly ILogger<GetSomeDataQueryHandler> _logger;

    public GetSomeDataQueryHandler(
        IUnitOfWork unit,
        ILogger<GetSomeDataQueryHandler> logger)
    {
        _unit = unit;
        _logger = logger;
    }

    public async Task<PagedResult<SomeDataDto>> Handle(GetSomeDataQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting some data with {@Request}", request);
        var (total, data) = await _unit.SomeData.GetData(request.Page, request.Count, e => true, cancellationToken);

        _logger.LogInformation("Got {Total} at {Page}", total, request.Page);

        return PagedResult<SomeDataDto>.Ok(
            data.Select(e => e.Adapt<SomeDataDto>()),
            request.Count,
            request.Page,
            total);
    }
}