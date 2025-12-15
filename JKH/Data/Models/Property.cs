namespace JKH.Models;

public class Property
{
    public int Id { get; set; }

    public string UserId { get; set; } = "";   // владелец (AspNetUsers.Id)

    public int BuildingId { get; set; }
    public Building Building { get; set; } = default!;

    public string Apartment { get; set; } = ""; // вводит только пользователь
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // если у тебя есть Bills, можешь оставить:
    public List<Bill> Bills { get; set; } = new();
}
