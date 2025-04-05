using FioTec.Service.Domain.Reports.DTOs;
using FioTec.Service.Domain.Reports.Entities;

namespace FioTec.Service.Domain.Reports.Mappers;

public static class EntityToDtoMapping
{
    public static ReportDto MapToDTO(this Report source)
    {
        return new ReportDto
        {
            Id = source.Id,
            RequestDate = source.RequestDate,
            Arbovirus = source.Arbovirus,
            StartWeek = source.StartWeek,
            EndWeek = source.EndWeek,
            IBGECode = source.IBGECode,
            City = source.City,
            UserId = source.UserId,
            ReportedCases = source.ReportedCases
        };
    }
}
