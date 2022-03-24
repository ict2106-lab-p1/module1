using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Device;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;

namespace LivingLab.Core.DomainServices;
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

    public Task<List<Device>> GetDevicesForLabProfile(string labLocation)
    {
        return _deviceRepository.GetDevicesForLabProfile(labLocation);
    }

    public void UpdateDeviceStatus(string deviceId, string deviceReviewStatus)
    {
        _deviceRepository.UpdateDeviceStatus(deviceId, deviceReviewStatus);
    }

    public Task<List<Device>> GetAllDevicesForReview(string labLocation)
    {
        return _deviceRepository.GetAllDevicesForReview(labLocation);
    }
    
    public Task<List<Device>> ViewDevice(string deviceType, string labLocation)
    {
        return _deviceRepository.GetAllDevicesByType(deviceType, labLocation);
    }

    public Task<List<ViewDeviceTypeDTO>> ViewDeviceType(string labLocation)
    {
        return _deviceRepository.GetViewDeviceType(labLocation);
    }
    
    public Task<Device> ViewDeviceDetails(int id)
    {
        return _deviceRepository.GetDeviceDetails(id);
    }
    public Task<Device> GetDeviceLastRow()
    {
        return _deviceRepository.GetLastRow();
    }
    public Task<Device> AddDevice(Device addedDevice)
    {
        return _deviceRepository.AddDevice(addedDevice);
    }
    public Task<Device> EditDeviceDetails(Device editedDevice)
    {
        return _deviceRepository.EditDeviceDetails(editedDevice);
    }
    public Task<Device> DeleteDevice(Device deletedDevice)
    {
        return _deviceRepository.DeleteDevice(deletedDevice);
    }
}
