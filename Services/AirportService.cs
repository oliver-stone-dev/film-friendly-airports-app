using film_friendly_airports_app.Models;
using Microsoft.EntityFrameworkCore;

namespace film_friendly_airports_app.Services;

public class AirportService : IAirportService
{
    private readonly AppDbContext _database;

    public AirportService(AppDbContext database)
    {
        _database = database;
    }

    public Airport GetAirportById(int airportId)
    {
        var data = _database.Airports.Where(a => a.Id == airportId)
                                     //.Include(a => a.Terminals)
                                     .FirstOrDefault()!;
        return data;
    }
    public List<Terminal> GetTerminalsByAirportId(int airportId)
    {
        var data = _database.Terminals.Where(t => t.AirportId == airportId).ToList();
        return data;
    }

    public List<Airport> SearchForAirport(string text)
    {
        var lookupText = $"\"{text}*\"";

        FormattableString query =
            $@"SELECT TOP 10 * FROM dbo.Airports 
            WHERE CONTAINS (Name,{lookupText}) 
            OR CONTAINS (Code,{lookupText}) 
            OR CONTAINS (Country,{lookupText});";

        var data = _database.Airports.FromSql(query).ToList();

        return data;
    }
}
