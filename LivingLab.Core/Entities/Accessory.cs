using System.ComponentModel.DataAnnotations;

namespace LivingLab.Domain.Entities;

public class Accessory : BaseEntity
{
    [Required]
    public string? status { get; set; }


    [Required]
    [DataType(DataType.Date)]
    public DateTime ValidityDate { get; set; }

    [Required]
    public Lab Lab { get; set; }
    [Required]
    public AccessoryType AccessoryType { get; set; }
}
