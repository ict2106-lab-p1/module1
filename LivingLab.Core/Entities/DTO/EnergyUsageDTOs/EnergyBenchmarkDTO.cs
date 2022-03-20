   
namespace LivingLab.Core.Entities.DTO.EnergyUsageDTOs;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyBenchmarkDTO
{
    public double EnergyUsageBenchmark { get; set; }
    public Lab Lab { get; set; }
    public Entities.Device Device { get; set; }
}
