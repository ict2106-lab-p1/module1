using LivingLab.Domain.Entities;

namespace LivingLab.Domain.Interfaces.Repositories;

public interface IDeviceRepository : IRepository<Device>
{
    Task<List<Device>> GetDeviceWithDeviceType();
    Task<Device> GetDeviceDetails(int id);
}
