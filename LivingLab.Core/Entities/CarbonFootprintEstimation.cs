using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;
public class CarbonFootprintEstimation: BaseEntity
{
    [Required] // in kilograms of CO2 equivalent
    public double CO2Emission { get; set; }
    [Required] // energy usage log entry that was used to calculate this carbon footprint entry
    public EnergyUsageLog EnergyUsageLog { get; set; } = null!;
}