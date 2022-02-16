using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;

public interface IEnergyUsageRepository : IRepository<EnergyUsageLog>
{
    Task<List<EnergyUsageLog>> GetUsageByDeviceId(int id);
    Task<List<EnergyUsageLog>> GetUsageByDeviceType(string deviceType);
    Task<List<EnergyUsageLog>> GetUsageByLabId(int id);
    Task BulkInsertAsync(ICollection<EnergyUsageLog> logs);
}
