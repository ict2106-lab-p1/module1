using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IEnergyLogDomainService
{
    Task<EnergyUsageLog> Log(EnergyUsageLog log);
    Task CheckThreshold(int deviceId);
}
