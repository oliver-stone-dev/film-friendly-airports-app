using film_friendly_airports_app.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace film_friendly_airports_app.DataTransferObjects;

public class ReviewDTO
{
    public int Id { get; set; }
    public int TerminalId { get; set; }
    public string? AccountId { get; set; }
    public bool Recommended { get; set; }
    public string? DateTime { get; set; }
    public string? Comment { get; set; }
}
