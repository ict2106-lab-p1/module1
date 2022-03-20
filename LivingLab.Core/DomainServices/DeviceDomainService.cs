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
    public Task<List<Device>> ViewDevice(string deviceType)
    {
        return _deviceRepository.GetAllDevicesByType(deviceType);
    }

    public Task<List<ViewDeviceTypeDTO>> ViewDeviceType()
    {
        return _deviceRepository.GetViewDeviceType();
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
