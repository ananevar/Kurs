namespace JKH.Models;

public class Street
{
    public int Id { get; set; }
    public string Name { get; set; } = "";

    public int DistrictId { get; set; }
    public District District { get; set; } = default!;

    public List<Building> Buildings { get; set; } = new();
}
