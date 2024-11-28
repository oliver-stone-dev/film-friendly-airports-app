using film_friendly_airports_app.Models;

namespace film_friendly_airports_app.Services;
public interface IReportService
{
    Report GetById(int id);
    void AddReport(Report report);
}
