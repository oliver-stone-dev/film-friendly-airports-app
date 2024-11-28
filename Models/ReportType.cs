using System.ComponentModel.DataAnnotations;

namespace film_friendly_airports_app.Models;

public class ReportType
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public ICollection<Report> Reports { get; } = new List<Report>();
}
