using System.IO;

namespace JKH.Models;

public class District
{
    public int Id { get; set; }
    public string Name { get; set; } = "";

    public int CityId { get; set; }
    public City City { get; set; } = default!;

    public List<Street> Streets { get; set; } = new();
}
