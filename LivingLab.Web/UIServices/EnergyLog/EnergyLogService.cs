using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;

namespace LivingLab.Web.UIServices.EnergyLog;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyLogService : IEnergyLogService
{
    private readonly IEnergyLogDomainService _energyLogDomainService;
    
    public EnergyLogService(IEnergyLogDomainService energyLogDomainService)
    {
        _energyLogDomainService = energyLogDomainService;
    }
    
    public Task Log(EnergyUsageLog log)
    {
        return _energyLogDomainService.Log(log);
    }
} 
