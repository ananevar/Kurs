using System.ComponentModel.DataAnnotations;

namespace JKH.Models;

public class Meter
{
    public int Id { get; set; }

    public int PropertyId { get; set; }
    public Property Property { get; set; } = default!;

    public int ServiceTypeId { get; set; }
    public ServiceType ServiceType { get; set; } = default!;

    [MaxLength(100)]
    public string? SerialNumber { get; set; }

    public DateOnly? InstalledAt { get; set; }
    public bool IsActive { get; set; } = true;

    public List<MeterReading> Readings { get; set; } = new();
    public List<BillLine> BillLines { get; set; } = new();
}
