namespace LivingLab.Core.Entities.DTO.EnergyUsage;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
///
/// JOEY: most likely for EnergyUsageTrendAllLab
public class MonthlyEnergyUsageDTO 
{
    // public string? Month { get; set; }
    //
    // public int TotalEnergyUsage { get; set;}
    
    public List<EnergyUsageLog> Logs { get; set; }
    public Entities.Lab Lab { get; set; }
}
