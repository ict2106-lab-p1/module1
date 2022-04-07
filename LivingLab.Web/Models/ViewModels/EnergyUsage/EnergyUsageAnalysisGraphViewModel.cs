namespace LivingLab.Web.Models.ViewModels.EnergyUsage;

/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class EnergyUsageAnalysisGraphViewModel
{
    public EnergyUsageTrendSelectedLabViewModel SelectedLabEnergyUsage { get; set; } = new();
    public EnergyUsageTrendAllLabViewModel AllLabEnergyUsage { get; set; } = new();
}
