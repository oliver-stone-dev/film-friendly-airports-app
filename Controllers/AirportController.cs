using film_friendly_airports_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using film_friendly_airports_app.Models;
using film_friendly_airports_app.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;


namespace film_friendly_airports_app.Controllers;

[Route("/airports")]
[ApiController]
public class AirportController : ControllerBase
{
    private readonly IAirportService _airportService;
    private readonly IReviewService _reviewService;
    private readonly ILogger<AirportController> _logger;

    public AirportController(IAirportService airportService, IReviewService reviewService, ILogger<AirportController> logger)
    {
        _reviewService = reviewService;
        _airportService = airportService;
        _logger = logger;

        _logger.LogInformation("Airport Controller Instantiated");
    }

    [HttpGet("{id}")]
    public ActionResult<AirportDTO> GetAirportById(int id)
    {
        _logger.LogInformation("Airport Get Request Received");

        var data = _airportService.GetAirportById(id);

        if (data == null)
        {
            return NotFound();
        }

        //convert to data transfer object
        var dto = data.ToAirportDTO();

        return Ok(dto);
    }


    [HttpGet("{id}/stats")]
    public ActionResult<AirportStatsDTO> GetAirportStatsById(int id)
    {
        var totalReviews = _reviewService.GetAirportReviewCount(id);
        var averageRating = _reviewService.GetAirportRatingAvg(id);

        var statsDTO = new AirportStatsDTO
        {
            AverageRating = averageRating,
            TotalReviews = totalReviews
        };

        return Ok(statsDTO);
    }

    [HttpGet("{id}/terminals")]
    public ActionResult<IEnumerable<TerminalDTO>> GetTerminalsByAirportId(int id, [FromQuery]int terminalId = 0)
    {
        var data = _airportService.GetTerminalsByAirportId(id);

        if (data == null)
        {
            return NotFound();
        }

        //Filter terminal id
        var filtered = data.Where(t => (terminalId == 0) || (terminalId == t.Id)).ToList();

        //convert to data transfer object
        var dto = filtered.Select(t => t.ToTerminalDTO());

        return Ok(dto);
    }

    [HttpGet]
    public ActionResult<IEnumerable<AirportDTO>> Search([FromQuery] string search)
    {
        var data = _airportService.SearchForAirport(search);

        if (data == null)
        {
            return NotFound();
        }

        //convert to data transfer object
        var dto = data.Select(a => a.ToAirportDTO());

        return Ok(dto);
    }
}
