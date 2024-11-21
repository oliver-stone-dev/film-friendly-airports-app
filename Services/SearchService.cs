using film_friendly_airports_app.Models;
using Microsoft.EntityFrameworkCore;

namespace film_friendly_airports_app.Services;

public class SearchService : ISearchService
{
    private readonly Database _database;

    public SearchService(Database database)
    {
        _database = database;
    }

    public IEnumerable<Airport> SearchForAirport(string text)
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
