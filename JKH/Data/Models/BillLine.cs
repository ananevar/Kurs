namespace JKH.Models;

public class BillLine
{
    public int Id { get; set; }

    public int BillId { get; set; }
    public Bill Bill { get; set; } = default!;

    public int MeterId { get; set; }
    public Meter Meter { get; set; } = default!;

    public int? PrevReadingId { get; set; }
    public int? CurrReadingId { get; set; }

    public decimal PrevValue { get; set; }
    public decimal CurrValue { get; set; }
    public decimal Consumption { get; set; }

    public decimal TariffPrice { get; set; }
    public decimal Amount { get; set; }
}
