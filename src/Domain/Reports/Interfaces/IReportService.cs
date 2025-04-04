using FioTec.Service.Domain.Reports.DTOs;
using Infrastructure.Adapter.InfoDengue.DTOs;

namespace FioTec.Service.Domain.Reports.Interfaces;

public interface IReportService
{
    Task<ReportDto> GenerateReportAsync(InfodengueRequestDto reportRequest);
}
