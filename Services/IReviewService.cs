using film_friendly_airports_app.Models;
namespace film_friendly_airports_app.Services;

public interface IReviewService
{
    Review GetById(int id);

    List<Review> GetFilteredReviews(int airportId,int terminalId,int offset,int maxReturn);

    void AddReview(Review review);
}
