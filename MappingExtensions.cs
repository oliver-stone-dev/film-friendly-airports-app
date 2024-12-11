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

    public static Airport ToAirport(this AirportDTO airportDTO)
    {
        return new Airport
        {
            Id = airportDTO.Id,
            Name = airportDTO.Name,
            Address = airportDTO.Address,
            Code = airportDTO.Code,
            NoTerminals = airportDTO.NoTerminals,
            Telephone = airportDTO.Telephone,
            Website = airportDTO.Website
        };
    }

    public static TerminalDTO ToTerminalDTO(this Terminal terminal)
    {
        return new TerminalDTO
        {
            Id = terminal.Id,
            Name = terminal.Name,
            AirportId = terminal.AirportId,
            ScannerType = terminal.ScannerType,
            UsingCT = terminal.UsingCT
        };
    }

    public static Terminal ToTerminal(this TerminalDTO terminalDTO)
    {
        return new Terminal
        {
            Id = terminalDTO.Id,
            Name = terminalDTO.Name,
            AirportId = terminalDTO.AirportId,
            ScannerType = terminalDTO.ScannerType,
            UsingCT = terminalDTO.UsingCT
        };
    }

    public static ReportDTO ToReportDTO(this Report report)
    {
        return new ReportDTO
        {
            Id = report.Id,
            TypeId = report.TypeId,
            AccountId = report.AccountId,
            TerminalId = report.TerminalId,
            TimeStamp = report.TimeStamp
        };
    }

    public static Report ToReport(this ReportDTO reportDTO)
    {
        return new Report
        {
            Id = reportDTO.Id,
            TypeId = reportDTO.TypeId,
            AccountId = reportDTO.AccountId,
            TerminalId = reportDTO.TerminalId,
            TimeStamp = reportDTO.TimeStamp
        };
    }

    public static ReviewDTO ToReviewDTO(this Review review)
    {
        return new ReviewDTO
        {
            Id = review.Id,
            AccountId = review.AccountId,
            Comment = review.Comment,
            DateTime = review.DateTime,
            Rating = review.Rating,
            TerminalId = review.TerminalId
        };
    }

    public static Review ToReview(this ReviewDTO reviewDTO)
    {
        return new Review
        {
            Id = reviewDTO.Id,
            AccountId = reviewDTO.AccountId,
            Comment = reviewDTO.Comment,
            DateTime = reviewDTO.DateTime,
            Rating = reviewDTO.Rating,
            TerminalId = reviewDTO.TerminalId
        };
    }

    public static AccountDTO ToAccountDTO(this Account account)
    {
        return new AccountDTO
        {
            Id = account.Id,
            Email = account.Email
        };
    }

    public static Account ToAccount(this AccountDTO accountDTO)
    {
        return new Account
        {
            Id = accountDTO.Id!,
            Email = accountDTO.Email
        };
    }
}
