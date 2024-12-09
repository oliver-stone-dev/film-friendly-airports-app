﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace film_friendly_airports_app.Models;

public class Report
{
    
    [Key]
    public int Id { get; set; }

    [Required]
    public int TypeId { get; set; }

    [Required]
    [ForeignKey ("Account")]
    public string? AccountId { get; set; }

    [Required]
    public int TerminalId { get; set; }

    public string? TimeStamp { get; set; }
    public bool Result { get; set; }
    public Terminal? Terminal { get; set; }
    public Account? Account { get; set; }
    public ReportType? Type { get; set; }
}
