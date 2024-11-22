﻿using film_friendly_airports_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using film_friendly_airports_app.Models;
using Microsoft.AspNetCore.Authorization;


namespace film_friendly_airports_app.Controllers;

[Route("/airports")]
[ApiController]
public class AirportController : ControllerBase
{
    private readonly IAirportService _service;
    private readonly ILogger<AirportController> _logger;

    public AirportController(IAirportService service, ILogger<AirportController> logger)
    {
        _service = service;
        _logger = logger;

        _logger.LogInformation("Airport Controller Instantiated");
    }

    [HttpGet("{id}")]
    public ActionResult<Airport> GetAirportById(int id)
    {
        _logger.LogInformation("Airport Get Request Received");

        var data = _service.GetAirportById(id);

        if (data == null)
        {
            return NotFound();
        }

        return Ok(data);
    }

    [HttpGet("{id}/terminals")]
    public ActionResult<IEnumerable<Terminal>> GetTerminalsByAirportId(int id)
    {
        var data = _service.GetTerminalsByAirportId(id);

        if (data == null)
        {
            return NotFound();
        }

        return Ok(data);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Airport>> Search([FromQuery] string search)
    {
        var data = _service.SearchForAirport(search);

        if (data == null)
        {
            return NotFound();
        }

        return Ok(data);
    }
}
