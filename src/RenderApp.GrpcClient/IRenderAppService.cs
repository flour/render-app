using System.ServiceModel;
using RenderApp.Commons;
using RenderApp.GrpcClient.Contracts.Requests;
using RenderApp.GrpcClient.Contracts.Responses;

namespace RenderApp.GrpcClient;

[ServiceContract]
public interface IRenderAppService
{
    [OperationContract]
    IAsyncEnumerable<SomeDataResponse> GetSteam(CancellationToken token = default);

    [OperationContract]
    Task<PagedResult<SomeDataResponse>> GetPaged(GetSomeDataPagedRequest request, CancellationToken token = default);
}