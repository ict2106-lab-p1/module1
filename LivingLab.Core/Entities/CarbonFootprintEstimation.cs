using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class CarbonFootprintEstimation: BaseEntity
{
    [Required] // in kilograms of CO2 equivalent
    public double CO2Emission { get; set; }
    [Required] // energy usage log entry that was used to calculate this carbon footprint entry
    public EnergyUsageLog EnergyUsageLog { get; set; } = null!;
}
