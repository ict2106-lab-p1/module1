using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.UIServices.Device;

public interface IDeviceService
{
    Task<ViewDeviceViewModel> viewDevice();
}
