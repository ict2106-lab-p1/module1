using LivingLab.Web.ViewModels;

namespace LivingLab.Web.UIServices.Device;

public interface IAccessoryService
{
    Task<ViewAccessoryViewModel> viewAccessory();
}
