using System.ComponentModel.DataAnnotations;

namespace JKH.Models;

public class ServiceType
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = default!;   // ХВС, ГВС, Электроэнергия...

    [Required, MaxLength(20)]
    public string Unit { get; set; } = default!;   // m3, kWh

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<Meter> Meters { get; set; } = new();
    public List<Tariff> Tariffs { get; set; } = new();
}
