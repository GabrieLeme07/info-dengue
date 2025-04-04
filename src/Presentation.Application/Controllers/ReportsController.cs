using FioTec.Service.Domain.Reports.DTOs;
using FioTec.Service.Domain.Reports.Interfaces;
using Infrastructure.Adapter.InfoDengue.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FioTec.Service.Presentation.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController(IReportService reportService) : ControllerBase
{
    private readonly IReportService _reportService = reportService;

    /// <summary>
    /// Gera um relatório consultando a API do Infodengue e salva os dados no banco.
    /// </summary>
    /// <param name="request">Objeto com os dados da requisição.</param>
    /// <returns>Relatório gerado no formato ReportDto.</returns>
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
}
