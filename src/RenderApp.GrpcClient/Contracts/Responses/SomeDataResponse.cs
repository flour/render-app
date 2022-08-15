using System.Runtime.Serialization;

namespace RenderApp.GrpcClient.Contracts.Responses;

[DataContract]
public class SomeDataResponse
{
    [DataMember(Order = 1)] public string Id { get; set; }
    [DataMember(Order = 2)] public string Name { get; set; }
    [DataMember(Order = 3)] public int IntValue { get; set; }
    [DataMember(Order = 4)] public decimal DecimalValue { get; set; }
    [DataMember(Order = 5)] public DateTime DateTimeValue { get; set; }
}