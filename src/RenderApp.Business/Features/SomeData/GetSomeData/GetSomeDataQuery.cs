using MediatR;
using RenderApp.Business.Features.SomeData.Models;
using RenderApp.Commons;

namespace RenderApp.Business.Features.SomeData.GetSomeData;

public class GetSomeDataQuery : IRequest<PagedResult<SomeDataDto>>
{
    public int Count { get; set; }
    public int Page { get; set; }
}