using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;

public interface IDeviceRepository : IRepository<Device>
{
    Task<List<ViewDeviceTypeDTO>> GetViewDeviceType();
    Task<List<Device>> GetAllDevicesByType(string deviceType);
}
