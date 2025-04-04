using FioTec.Service.Domain.Reports.DTOs;

namespace FioTec.Service.Domain.Users.DTOs;

public record UserDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string CPF { get; init; }

    public List<ReportDto> Reports { get; init; }
}
