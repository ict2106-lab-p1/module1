using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IEnergyUsageLogDomainService
{
    Task LogUsage(EnergyUsageLog log);
    Task<float> CheckThreshold(int deviceId);
}
