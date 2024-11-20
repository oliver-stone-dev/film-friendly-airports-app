using film_friendly_airports_app.Models;

namespace film_friendly_airports_app.Services;

public interface IAirportService
{
    IEnumerable<Airport> GetAll();
}
