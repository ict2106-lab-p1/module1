using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.Models.DTOs;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageDTO
{
    public double EnergyUsage { get; set; }
    public double Interval { get; set; }
    public DateTime LoggedDate { get; set; }
    public LabViewModel Lab { get; set; }
    public DeviceViewModel Device { get; set; }
}
