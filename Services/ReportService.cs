using film_friendly_airports_app.Models;
using Microsoft.Identity.Client;

namespace film_friendly_airports_app.Services;

public class ReportService : IReportService
{
    private readonly AppDbContext _database;
    private readonly ILogger _logger;

    public ReportService(AppDbContext database, ILogger<ReportService> logger)
    {
        _database = database;
        _logger = logger;
    }

    public Report GetById(int id)
    {
        var data = _database.Reports.Where(r => r.Id == id).FirstOrDefault()!;
        return data;
    }

    public List<Report> GetAllTerminalReports(int terminalId)
    {
        var data = _database.Reports.Where(r => r.TerminalId == terminalId).ToList();
        return data;
    }

    public void AddReport(Report report)
    {
        try 
        {
            _database.Reports.Add(report);
            _database.SaveChanges();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
    }
}
