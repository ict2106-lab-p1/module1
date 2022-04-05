using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivingLab.Core.Entities;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public abstract class Equipment
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Status { get; set; }
    public string? ReviewStatus { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName = "Date")]
    public DateTime LastUpdated { get; set; }
}
