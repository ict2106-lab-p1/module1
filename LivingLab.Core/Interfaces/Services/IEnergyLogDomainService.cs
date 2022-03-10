using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Services;

public interface IEnergyLogDomainService
{
    Task Log(EnergyUsageLog log);
}
