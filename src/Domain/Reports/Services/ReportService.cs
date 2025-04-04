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

        var report = reportRequest.MapToEntity(user.Id);

        await _reportRepository.AddAsync(report);

        var reportDto = new ReportDto
        {
            Id = report.Id,
            RequestDate = report.RequestDate,
            Arbovirus = report.Arbovirus,
            StartWeek = report.StartWeek,
            EndWeek = report.EndWeek,
            IBGECode = report.IBGECode,
            City = report.City
        };

        return reportDto;
    }
}
