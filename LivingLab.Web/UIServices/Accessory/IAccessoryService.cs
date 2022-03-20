using LivingLab.Web.Models.ViewModels.Accessory;

namespace LivingLab.Web.UIServices.Accessory;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IAccessoryService
{
    Task<ViewAccessoryViewModel> ViewAccessory(string accessoryType);
    Task<ViewAccessoryTypeViewModel> ViewAccessoryType();
    Task<ViewAccessoryViewModel> AddAccessory(AccessoryDetailsViewModel viewModelInput);

    Task<AccessoryViewModel> DeleteAccessory(AccessoryViewModel deleteAccessory);

    Task<AccessoryDetailsViewModel> AddAccessoryDetails();
    Task<AccessoryViewModel> GetAccessory(int id);
    Task<AccessoryDetailsViewModel> EditAccessory(AccessoryDetailsViewModel viewModelInput);

    Task<AccessoryDetailsViewModel> EditAccessoryDetails(int id);
    

}
