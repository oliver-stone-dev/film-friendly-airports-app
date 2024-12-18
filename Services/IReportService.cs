using film_friendly_airports_app.DataTransferObjects;
using film_friendly_airports_app.Models;

namespace film_friendly_airports_app.Services;
public interface IReportService
{
    Report GetById(int id);

    List<Report> GetAllTerminalReports(int terminalId);

    List<ReportAlertDTO> GetReportAlertsForTerminal(int terminaldId);

    void AddReport(Report report);
}
