namespace LivingLab.Core.Entities.DTO.EnergyUsage;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class IndividualLabMonthlyEnergyUsageDTO
{
    public List<EnergyUsageLog> Logs { get; set; }
    public Entities.Lab Lab { get; set; }
}
