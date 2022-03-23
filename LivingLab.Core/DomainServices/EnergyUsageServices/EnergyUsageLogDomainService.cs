using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;

namespace LivingLab.Core.DomainServices.EnergyUsageServices;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageLogDomainService : IEnergyUsageLogDomainService
{
    public Task LogUsage(EnergyUsageLog log)
    {
        throw new NotImplementedException();
    }

    public Task<float> CheckThreshold(int deviceId)
    {
        throw new NotImplementedException();
    }
}
