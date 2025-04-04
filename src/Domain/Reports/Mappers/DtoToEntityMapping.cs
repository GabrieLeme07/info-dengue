using FioTec.Service.Domain.Reports.Entities;
using FioTec.Service.Domain.Users.Entities;
using Infrastructure.Adapter.InfoDengue.DTOs;

namespace FioTec.Service.Domain.Reports.Mappers;

public static class DtoToEntityMapping
{
    public static User MapToEntity(this InfodengueRequestDto source)
    {
        return new User
        {
            CPF = source.CPF,
            Name = source.UserName
        };
    }

    public static Report MapToEntity(this InfodengueRequestDto source, Guid userId)
    {
        return new Report
        {
            RequestDate = DateTime.UtcNow,
            Arbovirus = source.Arbovirus,
            StartWeek = source.StartWeek,
            EndWeek = source.EndWeek,
            IBGECode = source.IBGECode,
            City = source.City,
            UserId = userId
        };
    }
}
