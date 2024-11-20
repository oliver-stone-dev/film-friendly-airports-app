using film_friendly_airports_app.Models;

namespace film_friendly_airports_app.Services;

public class AirportService : IAirportService
{
    private readonly Database _database;

    public AirportService(Database database)
    {
        _database = database;
    }

    public IEnumerable<Airport> GetAll()
    {
        return _database.Airports.ToList<Airport>();
    }
}
