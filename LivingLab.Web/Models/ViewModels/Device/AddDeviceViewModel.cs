namespace LivingLab.Web.Models.ViewModels.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AddDeviceViewModel
{
    public String? NewType { get; set; }
    public DeviceViewModel? Device { get; set; }
    public List<String>? DeviceTypes { get; set; }
}
