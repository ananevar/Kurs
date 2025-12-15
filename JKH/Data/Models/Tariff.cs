using System.ComponentModel.DataAnnotations;

namespace JKH.Models;

public class Tariff
{
    public int Id { get; set; }

    public int ServiceTypeId { get; set; }
    public ServiceType ServiceType { get; set; } = default!;

    [Range(0, 999999)]
    public decimal PricePerUnit { get; set; }

    public DateOnly ValidFrom { get; set; }
    public DateOnly? ValidTo { get; set; }
}
