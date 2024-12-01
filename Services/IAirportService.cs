using film_friendly_airports_app.Models;

namespace film_friendly_airports_app.Services;

public interface IAirportService
{
    Airport GetAirportById(int airportId);
    List<Airport> SearchForAirport(string text);
    List<Terminal> GetTerminalsByAirportId(int airportId);
}
