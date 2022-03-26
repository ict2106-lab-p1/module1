namespace LivingLab.Core.Entities.DTO.EnergyUsageDTOs;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageDTO
{
    public List<EnergyUsageLog> Logs { get; set; }
    public double EnergyUsageBenchmark { get; set; }
    public Lab Lab { get; set; }
}
