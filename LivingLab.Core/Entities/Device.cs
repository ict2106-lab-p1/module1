using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivingLab.Core.Entities;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class Device : BaseEntity
{
    [Required]
    [DataType(DataType.Date)]
<<<<<<< HEAD
    [Column(TypeName = "Date")]
=======
    [Column(TypeName="Date")]
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
    public DateTime LastUpdated { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string? SerialNo { get; set; }
    [Required]
    public Lab? Lab { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public string Type { get; set; }
    public string? Description { get; set; }
<<<<<<< HEAD
    public double? Threshold { get; set; }
=======
    public double? Threshold { get; set; } 
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
}
