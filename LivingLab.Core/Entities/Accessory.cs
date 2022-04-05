using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivingLab.Core.Entities;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class Accessory: Equipment
{   
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Status { get; set; }
    [Required]
    public int LabId { get; set; }

    [Required] 
    public int AccessoryTypeId { get; set; }

    public Lab? Lab { get; set; }

    public AccessoryType? AccessoryType { get; set; }

    public string? LabUserId { get; set; }

    [DataType(DataType.Date)]
    [Column(TypeName = "Date")]
    public DateTime? DueDate { get; set; }
}
