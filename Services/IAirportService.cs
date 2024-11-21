using film_friendly_airports_app.Models;

namespace film_friendly_airports_app.Services;

public interface IAirportService
{
    Airport GetAllById(int airportId);
    Airport GetAirportById(int airportId);
    IEnumerable<Airport> Search(string text);
    IEnumerable<Terminal> GetTerminalsByAirportId(int airportId);
}
