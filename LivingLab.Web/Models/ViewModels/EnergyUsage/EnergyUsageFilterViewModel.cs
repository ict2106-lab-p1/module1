namespace LivingLab.Web.Models.ViewModels.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageFilterViewModel
{
    public double EnergyUsage { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public EnergyUsageLabViewModel Lab { get; set; }
}
