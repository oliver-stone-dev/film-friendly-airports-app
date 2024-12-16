using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace film_friendly_airports_app.Models;

public class Review
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int TerminalId { get; set; }

    [Required]
    [ForeignKey("Account")]
    public string? AccountId { get; set; }

    [Required]
    public bool Recommended { get; set; }

    [Required]
    public string? DateTime { get; set; }

    public string? Comment { get; set; }

    public Terminal? Terminal { get; set; }

    public Account? Account { get; set; }
}
