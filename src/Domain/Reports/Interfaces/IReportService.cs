using FioTec.Service.Domain.Reports.DTOs;
using Infrastructure.Adapter.InfoDengue.DTOs;

namespace FioTec.Service.Domain.Reports.Interfaces;

public interface IReportService
{
    Task<ReportDto> GenerateReportAsync(InfodengueRequestDto reportRequest);
    Task<IEnumerable<ReportDto>> GetAllReportsAsync();
    Task<IEnumerable<ReportDto>> GetReportsByCitiesAsync(List<string> cities);
    Task<IEnumerable<ReportDto>> GetReportsByIBGECodeAsync(string ibgeCode);
    Task<int> GetTotalReportedCasesByCitiesAsync(List<string> cities);
    Task<int> GetTotalReportedCasesByArbovirusAsync(string arbovirus);
    Task<IEnumerable<ReportDto>> GetReportsByFiltersAsync(string ibgeCode, int startWeek, int endWeek, string arbovirus);
}
