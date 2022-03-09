using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Services;

namespace LivingLab.Core.DomainServices;

public class EnergyUsageService : IEnergyUsageService
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
