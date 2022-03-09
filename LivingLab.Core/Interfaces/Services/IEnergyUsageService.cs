using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Services;

public interface IEnergyUsageService
{
    Task LogUsage(EnergyUsageLog log);
    Task<float> CheckThreshold(int deviceId);
}
