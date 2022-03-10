using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.UIServices.LivingLab;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILivingLabDashboardService
{
    Task<ViewDeviceViewModel> viewDevice();
}
