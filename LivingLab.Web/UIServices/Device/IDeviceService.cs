using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.UIServices.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IDeviceService
{
    Task<ViewDeviceViewModel> ViewDevice(string deviceType);
    Task<ViewDeviceTypeViewModel> ViewDeviceType();
}
