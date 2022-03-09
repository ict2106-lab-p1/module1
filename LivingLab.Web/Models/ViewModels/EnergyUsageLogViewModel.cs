using LivingLab.Core.Entities.Identity;

namespace LivingLab.Web.Models.ViewModels;

public class EnergyUsageLogViewModel
{
    public double EnergyUsage { get; set; }
    public double Interval { get; set; }
    public DateTime LoggedDate { get; set; }
    public ApplicationUser LoggedBy { get; set; }
    public LabViewModel Lab { get; set; }
    public DeviceViewModel Device { get; set; }
}
