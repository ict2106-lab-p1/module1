using LivingLab.Core.Entities;

namespace LivingLab.Core.Repositories.EnergyUsage;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface IEnergyUsageRepository : IRepository<EnergyUsageLog>
{
    Task BulkInsertAsync(ICollection<EnergyUsageLog> logs);
    Task<List<EnergyUsageLog>> GetDeviceEnergyUsageByDateTime(DateTime start, DateTime end);
    Task<List<EnergyUsageLog>> GetDeviceEnergyUsageByDeviceTypeAndDate(string deviceType, DateTime start, DateTime end);
    Task<List<EnergyUsageLog>> GetDeviceEnergyUsageByLabAndDate(int labId, DateTime? start, DateTime? end);
    Task<List<EnergyUsageLog>> GetLabEnergyUsageByLocationAndDate(string labLocation, DateTime? start, DateTime? end);
    Task<List<EnergyUsageLog>> GetLabEnergyUsageByDate(DateTime? start, DateTime? end);
    Task<List<EnergyUsageLog>> GetLabEnergyUsageByLabNameAndDate(string labName, DateTime start, DateTime end);
    Task<List<EnergyUsageLog>> GetLatestLogs(int size);
}
