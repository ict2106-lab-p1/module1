using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;

namespace LivingLab.Core.Interfaces.Repositories;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IDeviceRepository : IRepository<Device>
{
    Task<List<ViewDeviceTypeDTO>> GetViewDeviceType();
    Task<List<Device>> GetAllDevicesByType(string deviceType);
    Task<Device> GetDeviceDetails(int id);
    Task<Device> EditDeviceDetails(Device editedDevice);
}
