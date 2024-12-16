using film_friendly_airports_app.Models;
using System.ComponentModel.DataAnnotations;

namespace film_friendly_airports_app.DataTransferObjects;

public class TerminalDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int AirportId { get; set; }
}
