using System.Runtime.CompilerServices;
using Mapster;
using MediatR;
using RenderApp.Business.Features.SomeData.GetSomeData;
using RenderApp.Business.Features.SomeData.StreamData;
using RenderApp.Commons;
using RenderApp.GrpcClient;
using RenderApp.GrpcClient.Contracts.Requests;
using RenderApp.GrpcClient.Contracts.Responses;

namespace RenderApp.Api.Services;

internal class RenderAppService : IRenderAppService
{
    private readonly IMediator _mediator;
    private readonly ILogger<RenderAppService> _logger;

    public RenderAppService(IMediator mediator, ILogger<RenderAppService> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    public async IAsyncEnumerable<SomeDataResponse> GetSteam(
        [EnumeratorCancellation] CancellationToken token = default)
    {
        await foreach (var item in _mediator.CreateStream(new StreamDataQuery(), token))
            yield return item.Adapt<SomeDataResponse>();
    }

    public async Task<PagedResult<SomeDataResponse>> GetPaged(
        GetSomeDataPagedRequest request,
        CancellationToken token = default)
    {
        var result = await _mediator.Send(request.Adapt<GetSomeDataQuery>(), token);
        return result.Adapt<PagedResult<SomeDataResponse>>();
    }
}