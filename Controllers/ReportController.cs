using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using film_friendly_airports_app.Services;
using film_friendly_airports_app.Models;

namespace film_friendly_airports_app.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IReportService _service;

    public ReportController(IReportService service)
    {
        _service = service;
    }


    [HttpGet]
    public ActionResult<Report> GetById(int id)
    {
        var data = _service.GetById(id);

        if (data == null)
        {
            return NotFound();
        }

        return Ok(data);
    }

    [HttpPost]
    public ActionResult<Report> Add(Report report)
    {
        _service.AddReport(report);

        return CreatedAtAction(nameof(Report), new { id = report.Id}, report);
    }

}
