namespace LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class IndividualLabMonthlyEnergyUsageDTO 
{
    public string? LabLocation { get; set; }
    public string? Month { get; set; }
    public int TotalEnergyUsage { get; set;}
}