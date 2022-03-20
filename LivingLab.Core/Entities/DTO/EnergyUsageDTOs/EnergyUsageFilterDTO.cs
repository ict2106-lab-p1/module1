namespace LivingLab.Core.Entities.DTO.EnergyUsageDTOs;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageFilterDTO
{
    public double EnergyUsage { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public Lab Lab { get; set; }
}
