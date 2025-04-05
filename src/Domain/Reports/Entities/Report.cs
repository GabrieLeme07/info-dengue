using FioTec.Service.Domain.Users.Entities;
using System.ComponentModel.DataAnnotations;

namespace FioTec.Service.Domain.Reports.Entities;

public class Report
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime RequestDate { get; set; }

    [Required]
    public string Arbovirus { get; set; }

    [Required]
    public int StartWeek { get; set; }

    [Required]
    public int EndWeek { get; set; }

    [Required]
    public string IBGECode { get; set; }

    [Required]
    public string City { get; set; }

    public int ReportedCases { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}
