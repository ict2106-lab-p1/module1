using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivingLab.Core.Entities;

public class Accessory : BaseEntity
{
    [Required]
    public string? Status { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName="Date")]
    public DateTime LastUpdated { get; set; }
    [Required]
    public int LabId { get; set; }
    [Required]
    public int AccessoryTypeId { get; set; }
    
    public Lab? Lab { get; set; }

    public AccessoryType? AccessoryType { get; set; }
    
    public string? LabUserId { get; set; }
    
    [DataType(DataType.Date)]
    [Column(TypeName="Date")]
    public DateTime? DueDate { get; set; }
}
