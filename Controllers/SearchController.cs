using film_friendly_airports_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using film_friendly_airports_app.Models;

namespace film_friendly_airports_app.Controllers;

[Route("/search")]
[ApiController]
public class SearchController : ControllerBase
{
    public readonly ISearchService _service;

    public SearchController(ISearchService service)
    {
        _service = service;
    }

    [HttpGet ("{text}")]
    public ActionResult<IEnumerable<Airport>> Search(string text)
    {
        var data = _service.SearchForAirport(text);

        if (data == null)
        {
            return NotFound();
        }

        return Ok(data);
    }

}
