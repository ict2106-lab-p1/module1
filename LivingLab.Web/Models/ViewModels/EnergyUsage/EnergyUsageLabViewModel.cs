namespace LivingLab.Web.Models.ViewModels.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageLabViewModel
{
    public int LabId { get; set; }
    public string LabLocation { get; set; }
    public string Area { get; set; }
    public double EnergyUsageBenchmark { get; set; }
}
