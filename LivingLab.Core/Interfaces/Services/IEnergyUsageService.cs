using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Services;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IEnergyUsageService
{
    Task LogUsage(EnergyUsageLog log);
    Task<float> CheckThreshold(int deviceId);
}