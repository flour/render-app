using MediatR;
using RenderApp.Business.Features.SomeData.Models;

namespace RenderApp.Business.Features.SomeData.StreamData;

public class StreamDataQuery : IStreamRequest<SomeDataDto>
{
}