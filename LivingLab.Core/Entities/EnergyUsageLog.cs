using System.ComponentModel.DataAnnotations;

using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Entities;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class EnergyUsageLog : BaseEntity
{
    [Required]
    public double? EnergyUsage { get; set; }

    [Required]
    public TimeSpan Interval { get; set; }

    [Required]
    public DateTime LoggedDate { get; set; }

    public ApplicationUser? LoggedBy { get; set; }

    [Required]
    public int LabId { get; set; }

    [Required]
    public int DeviceId { get; set; }

    public Lab Lab { get; set; } = null!;

    public Device Device { get; set; } = null!;
}
