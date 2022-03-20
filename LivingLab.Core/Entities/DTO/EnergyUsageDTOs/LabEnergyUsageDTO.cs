namespace LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class LabEnergyUsageDTO 
{
    public string? LabLocation { get; set; }

    public int TotalEnergyUsage { get; set;}

    public double EnergyUsageCost { get; set;}

    public double EnergyUsageIntensity {get; set;}

    public int EnergyUsagePerHour { get; set;}
}
