namespace LivingLab.Web.Models.ViewModels.EnergyUsage;

public class EnergyUsageAnalysisGraphViewModel
{
    public EnergyUsageTrendSelectedLabViewModel SelectedLabEnergyUsage { get; set; } = new EnergyUsageTrendSelectedLabViewModel();
    public EnergyUsageTrendAllLabViewModel AllLabEnergyUsage { get; set; } = new EnergyUsageTrendAllLabViewModel();
    
}
