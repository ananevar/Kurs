namespace JKH.Models;

public class Building
{
    public int Id { get; set; }
    public string Number { get; set; } = ""; // "12", "12A", "3/1" и т.п.

    public int StreetId { get; set; }
    public Street Street { get; set; } = default!;

    public List<Property> Properties { get; set; } = new();
}
