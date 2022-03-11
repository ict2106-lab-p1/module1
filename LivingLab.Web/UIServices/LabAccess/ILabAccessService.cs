using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.UIServices.LabAccess;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabAccessService
{
    Task<ViewDeviceViewModel> viewDevice();
}
