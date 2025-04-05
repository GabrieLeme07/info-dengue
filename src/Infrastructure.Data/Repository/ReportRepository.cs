using FioTec.Service.Domain.Reports.Entities;
using FioTec.Service.Domain.Reports.Interfaces;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository;

public class ReportRepository(AppDbContext context) : RepositoryBase<Report>(context), IReportRepository
{
    public async Task<IEnumerable<Report>> GetAllAsync()
    {
        return await _context.Reports
            .Include(r => r.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<Report>> GetReportsByCitiesAsync(List<string> cities)
    {
        return await _context.Reports
            .Where(r => cities.Contains(r.City))
            .ToListAsync();
    }

    public async Task<IEnumerable<Report>> GetReportsByIBGECodeAsync(string ibgeCode)
    {
        return await _context.Reports
            .Where(r => r.IBGECode == ibgeCode)
            .ToListAsync();
    }

    public async Task<int> GetTotalReportedCasesByCitiesAsync(List<string> cities)
    {
        return await _context.Reports
            .Where(r => cities.Contains(r.City))
            .SumAsync(r => r.ReportedCases);
    }

    public async Task<int> GetTotalReportedCasesByArbovirusAsync(string arbovirus)
    {
        return await _context.Reports
            .Where(r => r.Arbovirus == arbovirus)
            .SumAsync(r => r.ReportedCases);
    }

    public async Task<IEnumerable<Report>> GetReportsByFiltersAsync(string ibgeCode, int startWeek, int endWeek, string arbovirus)
    {
        return await _context.Reports
            .Where(r => r.IBGECode == ibgeCode &&
                        r.StartWeek >= startWeek &&
                        r.EndWeek <= endWeek &&
                        r.Arbovirus == arbovirus)
            .ToListAsync();
    }
}
