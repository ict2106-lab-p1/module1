using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;

public class Logging : BaseEntity
{
    [Required]
    [DataType(DataType.Date)]
    public DateTime? Date { get; set; }
    public int? NoOfHoursLogged { get; set; }

    public string? DataUploaded { get; set; }
    public Lab Lab { get; set; }
}
