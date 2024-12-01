using film_friendly_airports_app.Models;
using Microsoft.EntityFrameworkCore;

namespace film_friendly_airports_app.Services;

public class ReviewService : IReviewService
{
    private readonly AppDbContext _database;
    private readonly ILogger _logger;

    public ReviewService(AppDbContext database, ILogger<ReviewService> logger)
    {
        _database = database;
        _logger = logger;
    }

    public Review GetById(int id)
    {
        Review data = new();

        try
        {
            data = _database.Reviews.Where(r => r.Id == id).FirstOrDefault()!;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        return data!;
    }

    public void AddReview(Review review)
    {
        try 
        {
            _database.Reviews.Add(review);
            _database.SaveChanges();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
    }

    public List<Review> GetFilteredReviews(
        int airportId,
        int terminalId,
        int offset,
        int maxReturn)
    {
        List<Review> reviews = new();

        try
        {
            reviews = _database.Reviews
            .Where(r => 
                (airportId == 0 || r.Terminal != null && r.Terminal.AirportId == airportId) &&
                (terminalId == 0 || r.TerminalId == terminalId))
            .Include(r => r.Terminal)
            .Skip(offset)
            .Take(maxReturn)
            .ToList();
        }
        catch (Exception e)
        {

        }

        return reviews;
    }
}
