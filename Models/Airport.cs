using System.ComponentModel.DataAnnotations;

namespace film_friendly_airports_app.Models;

public class Airport
{
    [Key]
    public int AirportId { get; set; }

    public string? Name { get; set; }

    [Required]
    public string? Code { get; set; }

    public string? Address { get; set; }

    public string? Telephone { get; set; }

    [Required]
    public int NoTerminals { get; set; }

    public byte[]? Image { get; set; }

    public ICollection<Terminal> Terminals { get; } = new List<Terminal>();
}
