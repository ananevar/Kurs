using System.ComponentModel.DataAnnotations;
using JKH.Data;

namespace JKH.Models;

public class UserPhoto
{
    [Key]
    public string UserId { get; set; } = default!;

    public byte[] Data { get; set; } = Array.Empty<byte>();

    [MaxLength(100)]
    public string ContentType { get; set; } = "image/jpeg";

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
