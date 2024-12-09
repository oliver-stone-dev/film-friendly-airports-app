using film_friendly_airports_app.DataTransferObjects;
using film_friendly_airports_app.Models;
using film_friendly_airports_app.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace film_friendly_airports_app.Controllers;

[Route("/reviews")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _service;

    public ReviewController(IReviewService service)
    {
        _service = service;
    }

    [HttpGet ("{id}")]
    public ActionResult<ReviewDTO> GetById(int id)
    {
        var data = _service.GetById(id);

        if (data == null)
        {
            return NotFound();
        }

        //get data transfer object
        var dto = data.ToReviewDTO();

        return Ok(dto);
    }

    [HttpGet]
    public ActionResult<IEnumerable<ReviewDTO>> GetAll(
        [FromQuery (Name = "airport")] int airportId, 
        [FromQuery (Name = "terminal")] int terminalId,
        [FromQuery] int offset,
        [FromQuery] string? sort,
        [FromQuery] int results = 10
    )
    {
        var data = _service.GetFilteredReviews(airportId, terminalId, offset, results);

        if (data == null)
        {
            return NotFound();
        }

        var dto = data.Select(r => r.ToReviewDTO()).ToList();

        return Ok(dto);
    }

    [Authorize]
    [HttpPost]
    public ActionResult<ReviewDTO> Add(ReviewDTO review)
    {
        var data = review.ToReview();

        _service.AddReview(data);

        return CreatedAtAction(nameof(GetById),new { id = review.Id}, review);
    }
}

