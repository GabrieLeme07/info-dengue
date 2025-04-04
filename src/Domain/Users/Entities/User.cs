using FioTec.Service.Domain.Reports.Entities;
using System.ComponentModel.DataAnnotations;

namespace FioTec.Service.Domain.Users.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Name { get; set; }

    [Required]
    [MaxLength(11)]
    public string CPF { get; set; }

    public virtual ICollection<Report> Reports { get; set; }
}
