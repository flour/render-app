using System.Runtime.Serialization;

namespace RenderApp.GrpcClient.Contracts.Requests;

[DataContract]
public class GetSomeDataPagedRequest
{
    [DataMember(Order = 1)] public int Page { get; set; }
    [DataMember(Order = 2)] public int Count { get; set; }
}