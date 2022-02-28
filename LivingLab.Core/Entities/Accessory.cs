using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LivingLab.Domain.Entities;

public class Accessory : BaseEntity
{
    [Required]
    public string? status { get; set; }


    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName="Date")]
    public DateTime ValidityDate { get; set; }

    [Required]
    public int LabId { get; set; }
    [Required]
    public int AccessoryTypeId { get; set; }
    public Lab? Lab { get; set; }

    public AccessoryType? AccessoryType { get; set; }
}
