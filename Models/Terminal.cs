using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace film_friendly_airports_app.Models;
public class Terminal
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public int AirportId { get; set; }

    [Required]
    public bool UsingCT { get; set; }

    public string? ScannerType { get; set; }

    public ICollection<Review> Reviews { get; } = new List<Review>();
    public ICollection<Report> Reports { get; } = new List<Report>();

    public Airport? Airport { get; set; }
}
