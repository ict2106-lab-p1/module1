namespace LivingLab.Core.Entities.DTO.EnergyUsage;

/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class LabEnergyUsageDTO
{
    public string? LabLocation { get; set; }

    public double TotalEnergyUsage { get; set; }

    public double EnergyUsageCost { get; set; }

    public double EnergyUsageIntensity { get; set; }
}
