using LivingLab.Web.ViewModels;

namespace LivingLab.Web.UIServices.Device;

public interface IDeviceService
{
    Task<ViewDeviceViewModel> viewDevice();
}
