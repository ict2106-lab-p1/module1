using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Interfaces.Repositories;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
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
    Task<List<EnergyUsageLog>> GetDeviceEnergyUsageByDateTime(DateTime start, DateTime end);
    Task<List<EnergyUsageLog>> GetDeviceEnergyUsageByDeviceTypeAndDate(string deviceType, DateTime start, DateTime end);
    Task<List<EnergyUsageLog>> GetDistinctDeviceEnergyUsage();
    Task<List<EnergyUsageLog>> GetDistinctLabEnergyUsage();
    Task<List<EnergyUsageLog>> GetAllDeviceByLab();
}
