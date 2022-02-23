using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;
public class EnergyUsagePredictionLog: BaseEntity
{
    [Required]
    public double EstimatedUsage { get; set; }
    [Required]
    public DateTime LoggedDate { get; set; }
    [Required]
    public Lab Lab { get; set; } = null!;
    [Required]
    public Device Device { get; set; } = null!;
}