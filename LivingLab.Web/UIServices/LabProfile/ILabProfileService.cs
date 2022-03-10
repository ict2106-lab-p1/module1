using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.UIServices.LabProfile;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabProfileService
{
    Task<ViewDeviceViewModel> viewDevice();
}
