using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
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
}
