using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class PowerGenerationMix: BaseEntity
{
    [Required] // NOTE Use one of the constants from LivingLab.Core.Constants.FuelTypes
    public string FuelName { get; set; } = null!;
    [Required]
    public double PercentContribution { get; set; }
    [Required]
    public double CO2PerUnitEnergy { get; set; }
    [Required]
    public DateTime LastUpdated { get; set; }
}
