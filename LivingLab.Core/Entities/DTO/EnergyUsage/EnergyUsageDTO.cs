namespace LivingLab.Core.Entities.DTO.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageDTO
{
    public List<EnergyUsageLog>? Logs { get; set; }
    public Entities.Lab? Lab { get; set; }
    public double Median { get; set; }
}
