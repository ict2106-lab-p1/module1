using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.Models.ViewModels;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageLogViewModel
{
    public double EnergyUsage { get; set; }
    public double Interval { get; set; }
    public DateTime LoggedDate { get; set; }
    public ApplicationUser LoggedBy { get; set; }
    public LabViewModel Lab { get; set; }
    public DeviceViewModel Device { get; set; }
}
