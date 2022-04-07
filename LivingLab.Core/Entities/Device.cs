using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class Device : Equipment
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? SerialNo { get; set; }
    [Required]
    public Lab? Lab { get; set; }
    [Required]
    public int LabId { get; set; }
    [Required]
    public string? Type { get; set; }
    public string? Description { get; set; }
    public double? Threshold { get; set; }
}
