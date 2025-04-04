using FioTec.Service.Domain.Reports.Entities;

namespace FioTec.Service.Domain.Reports.Interfaces;

public interface IReportRepository
{
    Task<Report> GetByIdAsync(int id);
    Task<Report> AddAsync(Report report);
    Task<IEnumerable<Report>> GetAllAsync();
}
