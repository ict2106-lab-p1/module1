using LivingLab.Web.Models.ViewModels.Accessory;

namespace LivingLab.Web.UIServices.Accessory;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IAccessoryService
{
    Task<ViewAccessoryViewModel> ViewAccessory(string accessoryType);
    Task<ViewAccessoryTypeViewModel> ViewAccessoryType();
    Task<ViewAccessoryViewModel> AddAccessory(AddAccessoryDetailsViewModel viewModelInput);

    Task<AccessoryViewModel> DeleteAccessory(AccessoryViewModel deleteAccessory);

    Task<AddAccessoryDetailsViewModel> AddAccessoryDetails();

}
