namespace LivingLab.Web.Models.ViewModels.Device;

public class AddDeviceViewModel
{
    public String NewType { get; set; }
    public DeviceViewModel Device { get; set; }
    public List<String> DeviceTypes { get; set; }
}
