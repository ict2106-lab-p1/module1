using LivingLab.Core.Entities.DTO.Device;
using LivingLab.Core.Repositories.Equipment;

namespace LivingLab.Core.DomainServices.Equipment.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class DeviceDomainService : IDeviceDomainService
{
    public readonly IDeviceRepository _deviceRepository;

    public DeviceDomainService(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    /// <summary>
    /// Get the devices type by lab Location
    /// </summary>
    /// <param name="labLocation">device's lab location</param>
    /// <returns>List of Device></returns>
    public Task<List<Entities.Device>> GetDevicesForLabProfile(string labLocation)
    {
        return _deviceRepository.GetDevicesForLabProfile(labLocation);
    }

    /// <summary>
    /// Update review status of the device
    /// </summary>
    /// <param name="deviceId"> id of the device</param>
    /// <param name="deviceReviewStatus"> device review status</param>
    public void UpdateDeviceStatus(string deviceId, string deviceReviewStatus)
    {
        _deviceRepository.UpdateDeviceStatus(deviceId, deviceReviewStatus);
    }

    /// <summary>
    /// function to get all the devices to review, based on lab location
    /// </summary>
    /// <param name="labLocation">lab's location</param>
    /// <returns>List of Device></returns>
    public Task<List<Entities.Device>> GetAllDevicesForReview(string labLocation)
    {
        return _deviceRepository.GetAllDevicesForReview(labLocation);
    }

    /// <summary>
    /// function to get a list of devices
    /// </summary>
    /// <returns>List of Device></returns>
    public Task<List<Entities.Device>> GetAllDevices()
    {
        return _deviceRepository.GetAllAsync();
    }

    /// <summary>
    /// function to get a list of devices based on device type and lab location
    /// </summary>
    /// <param name="deviceType"> type of device</param>
    /// <param name="labLocation"> lab's location </param>
    /// <returns>List of Device></returns>
    public Task<List<Entities.Device>> ViewDevice(string deviceType, string labLocation)
    {
        return _deviceRepository.GetAllDevicesByType(deviceType, labLocation);
    }

    /// <summary>
    /// function to get a list of devices and its quantity based on each device type
    /// </summary>
    /// <param name="labLocation">Device's lab location</param>
    /// <returns>List of ViewDeviceTypeDTO></returns>
    public async Task<List<ViewDeviceTypeDTO>> ViewDeviceType(string labLocation)
    {
        var collection = await _deviceRepository.GetViewDeviceType(labLocation);


        var iterator = collection.CreateIterator();

        List<ViewDeviceTypeDTO> deviceTypeDtos = new List<ViewDeviceTypeDTO>();
        for (var device = iterator.First(); iterator.HasNext(); device = iterator.Next())
        {
            deviceTypeDtos.Add(new ViewDeviceTypeDTO
            {
                Type = device.Type,
                Quantity = device.Quantity
            });
        }
        return deviceTypeDtos;
    }

    /// <summary>
    /// function to populate the edit device pop up modal 
    /// </summary>
    /// <param name="id">id of the device</param>
    /// <returns>Device</returns>
    public Task<Entities.Device> ViewDeviceDetails(int id)
    {
        return _deviceRepository.GetDeviceDetails(id);
    }

    /// <summary>
    /// function to get the last row of the device
    /// </summary>
    /// <returns>Device</returns>
    public Task<Entities.Device> GetDeviceLastRow()
    {
        return _deviceRepository.GetLastRow();
    }

    /// <summary>
    /// function to add device 
    /// </summary>
    /// <param name="addedDevice"> added device</param>
    /// <returns>Device</returns>
    public Task<Entities.Device> AddDevice(Entities.Device addedDevice)
    {
        return _deviceRepository.AddDevice(addedDevice);
    }

    /// <summary>
    /// function to populate edit device details
    /// </summary>
    /// <param name="editedDevice">edited device</param>
    /// <returns>Device</returns>
    public Task<Entities.Device> EditDeviceDetails(Entities.Device editedDevice)
    {
        return _deviceRepository.EditDeviceDetails(editedDevice);
    }

    /// <summary>
    /// function to delete device
    /// </summary>
    /// <param name="deletedDevice">deletedDevice</param>
    /// <returns>Device</returns>
    public Task<Entities.Device> DeleteDevice(Entities.Device deletedDevice)
    {
        return _deviceRepository.DeleteDevice(deletedDevice);
    }

    /// <summary>
    /// function to get all device types
    /// </summary>
    /// <returns>list of device types</returns> 
    public Task<List<String>> GetDeviceTypes()
    {
        return _deviceRepository.GetDeviceTypes();
    }
}
