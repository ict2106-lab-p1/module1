using LivingLab.Web.Models.ViewModels.Accessory;

namespace LivingLab.Web.UIServices.Accessory;

public interface IAccessoryService
{
    Task<ViewAccessoryViewModel> viewAccessory();
}
