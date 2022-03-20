using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.Interfaces.Services;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IDeviceDomainService
{
    Task<List<Device>> ViewDevice(string deviceType);
    Task<List<ViewDeviceTypeDTO>> ViewDeviceType();
    Task<Device> ViewDeviceDetails(int id);
    Task<Device> GetDeviceLastRow();
    Task<Device> AddDevice(Device addedDevice);
    Task<Device> EditDeviceDetails(Device editedDevice);
    Task<Device> DeleteDevice(Device deleteDevice);
}
