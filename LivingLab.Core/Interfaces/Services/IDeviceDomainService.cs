using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.Interfaces.Services;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IDeviceDomainService
{
    Task<List<Device>> ViewDevice(string deviceType, string labLocation);
    
    /***
    * For P1-5 you can use this method below to populate the device list in the lab profile,
    * by injecting this IDeviceDomainService in your UI's lab service.
    */
    Task<List<Device>> GetDevicesForLabProfile(string labLocation);
    void UpdateDeviceStatus(string deviceId, string deviceReviewStatus);
    Task<List<Device>> GetAllDevicesForReview(string labLocation);
    Task<List<ViewDeviceTypeDTO>> ViewDeviceType(string labLocation);
    Task<Device> ViewDeviceDetails(int id);
    Task<Device> GetDeviceLastRow();
    Task<Device> AddDevice(Device addedDevice);
    Task<Device> EditDeviceDetails(Device editedDevice);
    Task<Device> DeleteDevice(Device deleteDevice);
    Task<List<String>> GetDeviceTypes();
}
