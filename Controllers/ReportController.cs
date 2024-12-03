using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using film_friendly_airports_app.Services;
using film_friendly_airports_app.Models;
using film_friendly_airports_app.DataTransferObjects;

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


    [HttpGet]
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

    [HttpPost]
    public ActionResult<ReportDTO> Add(ReportDTO report)
    {
        var data = report.ToReport();

        _service.AddReport(data);

        return CreatedAtAction(nameof(GetById), new { id = report.Id}, report);
    }

}
