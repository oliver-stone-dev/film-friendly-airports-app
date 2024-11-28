using film_friendly_airports_app.DataTransferObjects;
using film_friendly_airports_app.Models;

namespace film_friendly_airports_app;

public static class MappingExtensions
{
    public static AirportDTO ToAirportDTO(this Airport airport)
    {
        return new AirportDTO
        {
            Id = airport.Id,
            Name = airport.Name,
            Address = airport.Address,
            Code = airport.Code,
            NoTerminals = airport.NoTerminals,
            Telephone = airport.Telephone,
            Website = airport.Website
        };
    }
}
