using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.DomainServices.Equipment.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IDeviceDomainService
{
    Task<List<Entities.Device>> GetAllDevices();
    Task<List<Entities.Device>> ViewDevice(string deviceType, string labLocation);
    
    /***
    * For P1-5 you can use this method below to populate the device list in the lab profile,
    * by injecting this IDeviceDomainService in your UI's lab service.
    */
    Task<List<Entities.Device>> GetDevicesForLabProfile(string labLocation);
    void UpdateDeviceStatus(string deviceId, string deviceReviewStatus);
    Task<List<Entities.Device>> GetAllDevicesForReview(string labLocation);
    Task<List<ViewDeviceTypeDTO>> ViewDeviceType(string labLocation);
    Task<Entities.Device> ViewDeviceDetails(int id);
    Task<Entities.Device> GetDeviceLastRow();
    Task<Entities.Device> AddDevice(Entities.Device addedDevice);
    Task<Entities.Device> EditDeviceDetails(Entities.Device editedDevice);
    Task<Entities.Device> DeleteDevice(Entities.Device deleteDevice);
    Task<List<String>> GetDeviceTypes();
}
