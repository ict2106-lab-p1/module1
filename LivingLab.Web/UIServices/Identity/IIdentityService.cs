using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.UIServices.Identity;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface IIdentityService
{
    Task<ViewDeviceViewModel> viewDevice();
}
