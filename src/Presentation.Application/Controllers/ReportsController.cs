using FioTec.Service.Domain.Reports.Interfaces;
using Infrastructure.Adapter.InfoDengue.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FioTec.Service.Presentation.Application.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{api-version:apiVersion}/[controller]")]
public class ReportsController(IReportService reportService) : ControllerBase
{
    private readonly IReportService _reportService = reportService;

    [HttpPost]
    public async Task<IActionResult> CreateReport([FromBody] InfodengueRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var reportDto = await _reportService.GenerateReportAsync(request);
            return Ok(reportDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllReports()
    {
        var reports = await _reportService.GetAllReportsAsync();
        return Ok(reports);
    }

    [HttpGet("cities")]
    public async Task<IActionResult> GetReportsByCities([FromQuery] string cities)
    {
        var cityList = cities.Split(',').Select(c => c.Trim()).ToList();
        var reports = await _reportService.GetReportsByCitiesAsync(cityList);
        return Ok(reports);
    }

    [HttpGet("ibge/{ibgeCode}")]
    public async Task<IActionResult> GetReportsByIBGECode(string ibgeCode)
    {
        var reports = await _reportService.GetReportsByIBGECodeAsync(ibgeCode);
        return Ok(reports);
    }

    [HttpGet("total/cities")]
    public async Task<IActionResult> GetTotalCasesByCities([FromQuery] string cities)
    {
        var cityList = cities.Split(',').Select(c => c.Trim()).ToList();
        var totalCases = await _reportService.GetTotalReportedCasesByCitiesAsync(cityList);
        return Ok(new { TotalCases = totalCases });
    }

    [HttpGet("total/arbovirus/{arbovirus}")]
    public async Task<IActionResult> GetTotalCasesByArbovirus(string arbovirus)
    {
        var totalCases = await _reportService.GetTotalReportedCasesByArbovirusAsync(arbovirus);
        return Ok(new { TotalCases = totalCases });
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetReportsByFilters([FromQuery] string ibgeCode,
                                                         [FromQuery] int startWeek,
                                                         [FromQuery] int endWeek,
                                                         [FromQuery] string arbovirus)
    {
        var reports = await _reportService.GetReportsByFiltersAsync(ibgeCode, startWeek, endWeek, arbovirus);
        return Ok(reports);
    }
}
