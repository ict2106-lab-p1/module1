using System.ComponentModel.DataAnnotations;

namespace LivingLab.Domain.Entities;

public class Report : BaseEntity
{
    [Required]
    [DataType(DataType.Date)]
    public DateTime? Date { get; set; }
    public int? NoOfHoursLogged { get; set; }

    public string? DeviceUsage { get; set; }
    public Lab Lab { get; set; }
}
