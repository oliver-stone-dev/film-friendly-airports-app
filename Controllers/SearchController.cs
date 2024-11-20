using film_friendly_airports_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace film_friendly_airports_app.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController : ControllerBase
{
    public readonly ISearchService _service;

    public SearchController(ISearchService service)
    {
        _service = service;
    }
}
