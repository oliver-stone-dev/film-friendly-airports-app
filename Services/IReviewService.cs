using film_friendly_airports_app.Models;
namespace film_friendly_airports_app.Services;

public interface IReviewService
{
    Review GetById(int id);
    void AddReview(Review review);
}
