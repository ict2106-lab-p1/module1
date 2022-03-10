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
    public DateTime LastUpdated { get; set; }
    public string? SerialNo { get; set; }
    [Required]
    public Lab? Lab { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public string Type { get; set; }
    public string? Description { get; set; }
    public double? Threshold { get; set; }
}
