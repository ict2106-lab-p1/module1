using LivingLab.Core.Entities;

namespace LivingLab.Core.DomainServices.EnergyLog;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IEnergyLogDomainService
{
    Task<EnergyUsageLog> Log(EnergyUsageLog log);
    bool ExceedThreshold(int deviceId, double currentEnergyUsage);
    Task<List<EnergyUsageLog>> GetLogs(int size);
}
