using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace film_friendly_airports_app.Models;
public class Review
{
    [Key]
    public int ReviewId { get; set; }

    [ForeignKey ("TerminalId")]
    public int TerminalId { get; set; }

    [Required]
    public int Rating { get; set; }

    [Required]
    public string? DateTime { get; set; }

    public string? Comment { get; set; }

    public byte[]? Image { get; set; }
}
