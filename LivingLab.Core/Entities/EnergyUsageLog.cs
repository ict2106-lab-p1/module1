using System.ComponentModel.DataAnnotations;

using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Entities;
public class EnergyUsageLog : BaseEntity
{
    [Required]
    public double? EnergyUsage { get; set; }
    [Required]
    public TimeSpan? Interval { get; set; }
    [Required]
    public DateTime? LoggedDate { get; set; }
    public ApplicationUser? LoggedBy { get; set; }
    [Required]
    public Lab? Lab { get; set; }
    [Required]
    public Device? Device { get; set; }
}
