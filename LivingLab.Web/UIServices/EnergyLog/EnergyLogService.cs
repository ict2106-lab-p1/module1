using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Services;

namespace LivingLab.Web.UIServices.EnergyLog;

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
