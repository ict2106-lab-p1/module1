namespace LivingLab.Core.Entities.DTO.EnergyUsage;

/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class EnergyComparisonGraphDTO
{
    public string? LabLocation { get; set; }

    public double TotalEnergyUsage { get; set; }

    public double EnergyUsageIntensity { get; set; }

    public double Benchmark { get; set; }
}
