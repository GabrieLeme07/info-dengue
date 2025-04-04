using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Adapter.InfoDengue.DTOs;

public record InfodengueRequestDto
{
    public string Arbovirus { get; init; }
    public int StartWeek { get; init; }
    public int EndWeek { get; init; }
    public string IBGECode { get; init; }
    public string City { get; init; }
    public string Disease { get; init; }

    [Required]
    public string CPF { get; init; }

    [Required]
    public string UserName { get; init; }
}
