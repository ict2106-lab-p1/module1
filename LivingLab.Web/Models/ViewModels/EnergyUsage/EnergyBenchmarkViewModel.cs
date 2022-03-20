using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.Models.ViewModels.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyBenchmarkViewModel
{
    public double EnergyUsage { get; set; }
    public EnergyUsageLabViewModel Lab { get; set; }
    public DeviceViewModel Device { get; set; }
}
