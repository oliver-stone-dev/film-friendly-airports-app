using film_friendly_airports_app.Models;

namespace film_friendly_airports_app.Services;

public interface IAirportService
{
    Airport GetAirportById(int airportId);
    IEnumerable<Airport> SearchForAirport(string text);
    IEnumerable<Terminal> GetTerminalsByAirportId(int airportId);
}
