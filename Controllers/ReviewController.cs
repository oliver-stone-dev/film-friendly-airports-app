using film_friendly_airports_app.Models;
using film_friendly_airports_app.Services;
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
    public ActionResult<Review> GetById(int id)
    {
        var data = _service.GetById(id);

        if (data == null)
        {
            return NotFound();
        }

        return Ok(data);
    }

    [HttpPut]
    public ActionResult AddReview(Review review)
    {
        _service.AddReview(review);
        return CreatedAtAction("GetById",new Review { ReviewId = review.ReviewId},review);
    }

}

