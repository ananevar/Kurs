using System.ComponentModel.DataAnnotations;

namespace JKH.Models;

public class MeterReading
{
    public int Id { get; set; }

    public int MeterId { get; set; }
    public Meter Meter { get; set; } = default!;

    // Для курсового удобно: первое число месяца (например 2025-12-01)
    public DateOnly ReadingDate { get; set; }

    [Range(0, 999999999)]
    public decimal Value { get; set; }

    public DateTime EnteredAt { get; set; } = DateTime.UtcNow;

    public string? EnteredByUserId { get; set; } // AspNetUsers.Id (nullable)
}
