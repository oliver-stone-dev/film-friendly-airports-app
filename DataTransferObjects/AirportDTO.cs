﻿using film_friendly_airports_app.Models;
using System.ComponentModel.DataAnnotations;

namespace film_friendly_airports_app.DataTransferObjects;

public class AirportDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Country { get; set; }
    public string? Website { get; set; }
}
