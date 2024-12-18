using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using film_friendly_airports_app.Services;
using film_friendly_airports_app.Models;
using film_friendly_airports_app.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;

namespace film_friendly_airports_app.Controllers;

[Route("/report")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IReportService _service;

    public ReportController(IReportService service)
    {
        _service = service;
    }


    [HttpGet ("{id}")]
    public ActionResult<ReportDTO> GetById(int id)
    {
        var data = _service.GetById(id);

        if (data == null)
        {
            return NotFound();
        }

        var dto = data.ToReportDTO();

        return Ok(data);
    }

    [HttpGet]
    public ActionResult<IEnumerable<ReportDTO>> Get([FromQuery] int terminalId = 0,
                                                    [FromQuery] string accountId = null!, 
                                                    [FromQuery] int type = 0)
    {
        if (terminalId == 0)
        {
            return NotFound();
        }

        var accountReports = _service.GetAllTerminalReports(terminalId);

        var report = accountReports.Where(r => (String.IsNullOrEmpty(accountId)) || r.AccountId == accountId)
                                   .Where(r => (type == 0) || r.TypeId == type)
                                   .ToList();

        if (report == null)
        {
            return NotFound();
        }

        var reportDTOs = report.Select(r => r.ToReportDTO()).ToList();

        return Ok(reportDTOs);
    }

    [HttpGet, Route("/report/alerts")]
    public ActionResult<IEnumerable<ReportAlertDTO>> GetAlertReports([FromQuery] int terminalId)
    {
        var data = _service.GetReportAlertsForTerminal(terminalId);

        if (data == null)
        {
            return NotFound();
        }

        return Ok(data);
    }

    [Authorize]
    [HttpPost]
    public ActionResult<ReportDTO> Add(ReportDTO report)
    {
        var data = report.ToReport();

        _service.AddReport(data);

        return CreatedAtAction(nameof(GetById), new { id = report.Id}, report);
    }

}
