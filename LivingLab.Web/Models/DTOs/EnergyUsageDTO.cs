using LivingLab.Web.Models.ViewModels;

namespace LivingLab.Web.Models.DTOs;

public class EnergyUsageDTO
{
    public double EnergyUsage { get; set; }
    public double Interval { get; set; }
    public DateTime LoggedDate { get; set; }
    public LabViewModel Lab { get; set; }
    public DeviceViewModel Device { get; set; }
}
