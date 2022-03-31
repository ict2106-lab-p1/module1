using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.Models.ViewModels.LivingLabDashboard;

namespace LivingLab.Web.UIServices.LivingLabDashboard;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILivingLabDashboardService
{
    Task<ViewDeviceViewModel> viewDevice();
    Task<LivingLabDashboardViewModel> GetAllLabs();
}
