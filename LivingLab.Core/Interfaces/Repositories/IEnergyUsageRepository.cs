using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Interfaces.Repositories;

public interface IEnergyUsageRepository : IRepository<EnergyUsageLog>
{
    Task<List<EnergyUsageLog>> GetUsageByDeviceId(int id);
    Task<List<EnergyUsageLog>> GetUsageByDeviceType(string deviceType);
    Task<List<EnergyUsageLog>> GetUsageByLabId(int id);
    /// <summary>Retrives all logs manually uploaded by user with userId</summary>
    /// <remarks>if userId is null, retrieves logs manually uploaded by any user</remarks>
    Task<List<EnergyUsageLog>> GetUsageByUser(ApplicationUser? user);
    Task BulkInsertAsync(ICollection<EnergyUsageLog> logs);
    Task BulkInsertAsyncByUser(ICollection<EnergyUsageLog> logs, ApplicationUser loggedBy);
}
