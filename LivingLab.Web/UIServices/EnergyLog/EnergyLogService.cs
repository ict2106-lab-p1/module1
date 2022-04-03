using AutoMapper;

using LivingLab.Core.DomainServices.EnergyLog;
using LivingLab.Core.Entities;
using LivingLab.Web.Models.DTOs;

namespace LivingLab.Web.UIServices.EnergyLog;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyLogService : IEnergyLogService
{
    private readonly IEnergyLogDomainService _energyLogDomainService;
    private readonly IMapper _mapper;
    
    public EnergyLogService(IEnergyLogDomainService energyLogDomainService , IMapper mapper)
    {
        _energyLogDomainService = energyLogDomainService;
        _mapper = mapper;
    }
    
    public Task Log(EnergyUsageLogDTO log)
    {
        var map = _mapper.Map<EnergyUsageLog>(log);
        return _energyLogDomainService.Log(map);
    }
} 
