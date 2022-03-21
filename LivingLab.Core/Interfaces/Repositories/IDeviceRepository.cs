using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.Interfaces.Repositories;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IDeviceRepository : IRepository<Device>
{
    Task<List<ViewDeviceTypeDTO>> GetViewDeviceType(string labLocation);
    Task<List<Device>> GetAllDevicesByType(string deviceType, string labLocation);
    Task<Device> GetDeviceDetails(int id);
    Task<Device> GetLastRow();
    Task<Device> AddDevice(Device addedDevice);
    Task<Device> EditDeviceDetails(Device editedDevice);
    Task<Device> DeleteDevice(Device deleteDevice);
}
