using System.ComponentModel.DataAnnotations;

namespace RenderApp.Domain;

public class SomeData
{
    public string Id { get; set; }
    [Required] [MaxLength(255)] public string Name { get; set; }
    public int IntValue { get; set; }
    public decimal DecimalValue { get; set; }
    public DateTime DateTimeValue { get; set; } = DateTime.UtcNow;
}