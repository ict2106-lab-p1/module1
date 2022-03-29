using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.UIServices.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IDeviceService
{
    Task<ViewDeviceViewModel> ViewDevice(string deviceType, string labLocation);
    Task<ViewDeviceTypeViewModel> ViewDeviceType(string labLocation);
    Task<DeviceViewModel> ViewDeviceDetails(int id);
    Task<DeviceViewModel> AddDevice(DeviceViewModel deviceViewModel);
    Task<DeviceViewModel> ViewAddDetails();
    Task<Boolean> SendReviewerEmail(string url);
    Task<DeviceViewModel> EditDevice(DeviceViewModel deviceViewModel);
    Task<DeviceViewModel> DeleteDevice(DeviceViewModel deviceViewModel);
}
