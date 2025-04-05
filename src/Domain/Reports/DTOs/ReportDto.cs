namespace FioTec.Service.Domain.Reports.DTOs;

public class ReportDto
{
    public int Id { get; init; }
    public DateTime RequestDate { get; init; }
    public string Arbovirus { get; init; }
    public int StartWeek { get; init; }
    public int EndWeek { get; init; }
    public string IBGECode { get; init; }
    public string City { get; init; }
    public int ReportedCases { get; init; }
    public Guid UserId { get; init; }
}
