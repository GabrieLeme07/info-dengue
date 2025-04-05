using FioTec.Service.Domain.Reports.Entities;

namespace FioTec.Service.Domain.Reports.Interfaces;

public interface IReportRepository
{
    Task<Report> GetByIdAsync(int id);
    Task<Report> AddAsync(Report report);
    Task<IEnumerable<Report>> GetAllAsync();

    // Retorna os relatórios filtrados por cidades
    Task<IEnumerable<Report>> GetReportsByCitiesAsync(List<string> cities);

    // Retorna os relatórios filtrados pelo código IBGE
    Task<IEnumerable<Report>> GetReportsByIBGECodeAsync(string ibgeCode);

    // Soma o total de casos epidemiológicos (ReportedCases) para as cidades informadas
    Task<int> GetTotalReportedCasesByCitiesAsync(List<string> cities);

    // Soma o total de casos epidemiológicos (ReportedCases) para uma determinada arbovirose
    Task<int> GetTotalReportedCasesByArbovirusAsync(string arbovirus);

    // Filtra os relatórios pelo código IBGE, semana de início, semana fim e arbovirose
    Task<IEnumerable<Report>> GetReportsByFiltersAsync(string ibgeCode, int startWeek, int endWeek, string arbovirus);
}
