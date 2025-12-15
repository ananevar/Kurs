namespace JKH.Models;

public class Bill
{
    public int Id { get; set; }

    public int PropertyId { get; set; }
    public Property Property { get; set; } = default!;

    // первое число месяца
    public DateOnly Period { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public decimal Total { get; set; }

    public List<BillLine> Lines { get; set; } = new();
}
