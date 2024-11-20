using film_friendly_airports_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using film_friendly_airports_app.Models;


namespace film_friendly_airports_app.Controllers;

[Route("api/[controller]")]
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

    [HttpGet]
    public ActionResult<IEnumerable<Airport>> GetAll()
    {
        _logger.LogInformation("Get Request Received");

        List<Airport> airports = _service.GetAll().ToList();

        return Ok(airports);
    }

}
