using film_friendly_airports_app.Models;
using Microsoft.EntityFrameworkCore;

namespace film_friendly_airports_app.Services;

public class AirportService : IAirportService
{
    private readonly Database _database;

    public AirportService(Database database)
    {
        _database = database;
    }

    public Airport GetAllById(int airportId)
    {
        var data = _database.Airports.Where(a => a.AirportId == airportId)
                                     .Include(a => a.Terminals)
                                     .FirstOrDefault()!;
        return data;
    }

    public Airport GetAirportById(int airportId)
    {
        var data = _database.Airports.Where(a => a.AirportId == airportId)
                                     .FirstOrDefault()!;
        return data;
    }
    public IEnumerable<Terminal> GetTerminalsByAirportId(int airportId)
    {
        var data = _database.Terminals.Where(t => t.AirportId == airportId);
        return data;
    }

    public IEnumerable<Airport> Search(string text)
    {
        var lookupText = $"\"{text}*\"";

        FormattableString query =
            $@"SELECT * FROM dbo.Airports 
            WHERE CONTAINS (Name,{lookupText}) 
            OR CONTAINS (Code,{lookupText}) 
            OR CONTAINS (Address,{lookupText});";

        var data = _database.Airports.FromSql(query);

        return data;
    }
}
