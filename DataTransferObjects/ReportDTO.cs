using film_friendly_airports_app.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace film_friendly_airports_app.DataTransferObjects;

public class ReportDTO
{
    public int Id { get; set; }
    public int TypeId { get; set; }
    public string? AccountId { get; set; }
    public int TerminalId { get; set; }
    public string? TimeStamp { get; set; }
    public string? Status { get; set; }
}
