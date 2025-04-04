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
}
