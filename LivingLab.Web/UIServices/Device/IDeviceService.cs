using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.UIServices.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IDeviceService
{
    Task<ViewDeviceViewModel> ViewDevice(string deviceType);
    Task<ViewDeviceTypeViewModel> ViewDeviceType();
    Task<DeviceViewModel> ViewDeviceDetails(int id);
    Task<DeviceViewModel> AddDevice(DeviceViewModel deviceViewModel);
    Task<DeviceViewModel> ViewAddDetails();
    Task<DeviceViewModel> EditDevice(DeviceViewModel deviceViewModel);
    Task<DeviceViewModel> DeleteDevice(DeviceViewModel deviceViewModel);
}
