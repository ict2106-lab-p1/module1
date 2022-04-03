namespace LivingLab.Web.Models.ViewModels.EnergyUsage;

public class EnergyUsageTrendAllLabViewModel
{
    // public double EnergyUsage { get; set; }
    // public LabViewModel Lab { get; set; }
    
    public List<EnergyUsageLogViewModel> Logs { get; set; }
    public EnergyUsageLabViewModel Lab { get; set; }
}
