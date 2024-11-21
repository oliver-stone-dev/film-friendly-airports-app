using film_friendly_airports_app.Models;
using Microsoft.EntityFrameworkCore;

namespace film_friendly_airports_app.Services;

public class ReviewService : IReviewService
{
    private readonly Database _database;

    public ReviewService(Database database)
    {
        _database = database;
    }

    public Review GetById(int id)
    {
        var data = _database.Reviews.Where(r => r.ReviewId == id).FirstOrDefault();
        return data!;
    }

    public void AddReview(Review review)
    {
        _database.Reviews.Add(review);
        _database.SaveChanges();
    }

}
