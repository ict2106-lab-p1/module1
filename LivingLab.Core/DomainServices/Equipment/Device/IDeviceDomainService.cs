using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.DomainServices.Equipment.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IDeviceDomainService
{
    /// <summary>
    /// function to get a list of devices
    /// </summary>
    /// <returns></returns>
    Task<List<Entities.Device>> GetAllDevices();

    /// <summary>
    /// function to get a list of devices based on device type and lab location
    /// </summary>
    /// <param name="deviceType"></param>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    Task<List<Entities.Device>> ViewDevice(string deviceType, string labLocation);

    /// <summary>
    /// Get the devices type by lab Location
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    Task<List<Entities.Device>> GetDevicesForLabProfile(string labLocation);

    /// <summary>
    /// Update review status of the device
    /// </summary>
    /// <param name="deviceId"></param>
    /// <param name="deviceReviewStatus"></param>
    void UpdateDeviceStatus(string deviceId, string deviceReviewStatus);

    /// <summary>
    /// function to get all the devices to review, based on lab location
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns></returns>
    Task<List<Entities.Device>> GetAllDevicesForReview(string labLocation);

    /// <summary>
    /// function to get a list of devices and its quantity based on each device type
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns>ViewDeviceTypeDTO</returns>
    Task<List<ViewDeviceTypeDTO>> ViewDeviceType(string labLocation);

    /// <summary>
    /// function to populate the edit device pop up modal 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Device</returns>
    Task<Entities.Device> ViewDeviceDetails(int id);

    /// <summary>
    /// function to get the last row of the device
    /// </summary>
    /// <returns>Device</returns>
    Task<Entities.Device> GetDeviceLastRow();

    /// <summary>
    /// function to add device 
    /// </summary>
    /// <param name="addedDevice"></param>
    /// <returns>Device</returns>
    Task<Entities.Device> AddDevice(Entities.Device addedDevice);

    /// <summary>
    /// function to populate edit device details
    /// </summary>
    /// <param name="editedDevice"></param>
    /// <returns>Device</returns>
    Task<Entities.Device> EditDeviceDetails(Entities.Device editedDevice);

    /// <summary>
    /// function to delete device
    /// </summary>
    /// <param name="deleteDevice"></param>
    /// <returns>Device</returns>
    Task<Entities.Device> DeleteDevice(Entities.Device deleteDevice);

    /// <summary>
    /// function to get all device types
    /// </summary>
    /// <returns>List<String>></returns>
    Task<List<String>> GetDeviceTypes();
}
