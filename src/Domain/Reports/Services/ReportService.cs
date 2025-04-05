using FioTec.Service.Domain.Reports.DTOs;
using FioTec.Service.Domain.Reports.Interfaces;
using FioTec.Service.Domain.Reports.Mappers;
using FioTec.Service.Domain.Users.Interfaces;
using Infrastructure.Adapter.InfoDengue.DTOs;
using Infrastructure.Adapter.InfoDengue.Interfaces;

namespace FioTec.Service.Domain.Reports.Services;

public class ReportService(
    IUserRepository userRepository,
    IReportRepository reportRepository,
    IInfodengueAdapter infodengueAdapter) : IReportService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IReportRepository _reportRepository = reportRepository;
    private readonly IInfodengueAdapter _infodengueAdapter = infodengueAdapter;

    public async Task<ReportDto> GenerateReportAsync(InfodengueRequestDto reportRequest)
    {
        var user = await _userRepository.GetByCPFAsync(reportRequest.CPF);
        user ??= await _userRepository.AddAsync(reportRequest.MapToEntity());

        var infodengueData = await _infodengueAdapter.GetReportAsync(reportRequest);

        var report = reportRequest.MapToEntity(user.Id, infodengueData.Sum(e => e.Casos));

        await _reportRepository.AddAsync(report);

        return report.MapToDTO();
    }

    public async Task<IEnumerable<ReportDto>> GetAllReportsAsync()
    {
        var reports = await _reportRepository.GetAllAsync();
        return reports.Select(r => r.MapToDTO());
    }

    public async Task<IEnumerable<ReportDto>> GetReportsByCitiesAsync(List<string> cities)
    {
        var reports = await _reportRepository.GetReportsByCitiesAsync(cities);
        return reports.Select(r => r.MapToDTO());
    }

    public async Task<IEnumerable<ReportDto>> GetReportsByIBGECodeAsync(string ibgeCode)
    {
        var reports = await _reportRepository.GetReportsByIBGECodeAsync(ibgeCode);
        return reports.Select(r => r.MapToDTO());
    }

    public async Task<int> GetTotalReportedCasesByCitiesAsync(List<string> cities)
        => await _reportRepository.GetTotalReportedCasesByCitiesAsync(cities);

    public async Task<int> GetTotalReportedCasesByArbovirusAsync(string arbovirus)
        => await _reportRepository.GetTotalReportedCasesByArbovirusAsync(arbovirus);

    public async Task<IEnumerable<ReportDto>> GetReportsByFiltersAsync(string ibgeCode, int startWeek, int endWeek, string arbovirus)
    {
        var reports = await _reportRepository.GetReportsByFiltersAsync(ibgeCode, startWeek, endWeek, arbovirus);
        return reports.Select(r => r.MapToDTO());
    }
}
