using AutoMapper;

using LivingLab.Core.DomainServices.EnergyLog;
using LivingLab.Core.Entities;
using LivingLab.Web.Models.DTOs;
using LivingLab.Web.Models.ViewModels.EnergyUsage;

namespace LivingLab.Web.UIServices.EnergyLog;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyLogService : IEnergyLogService
{
    private readonly IEnergyLogDomainService _energyLogDomainService;
    private readonly IMapper _mapper;

    public EnergyLogService(IEnergyLogDomainService energyLogDomainService, IMapper mapper)
    {
        _energyLogDomainService = energyLogDomainService;
        _mapper = mapper;
    }

    /// <summary>
    /// 1. Map log DTO to Energy Usage Log entity
    /// 2. Call Energy Log Domain Service to add the log into database
    /// </summary>
    /// <param name="log">Energy Usage Logs DTO</param>
    public Task Log(EnergyUsageLogDTO log)
    {
        var map = _mapper.Map<EnergyUsageLog>(log);
        return _energyLogDomainService.Log(map);
    }

    /// <summary>
    /// 1. Call Energy Log Domain Service to get specified number of latest logs
    /// 2. Map logs to Energy Usage Log ViewModel
    /// </summary>
    /// <param name="size"></param>
    public async Task<List<EnergyUsageLogViewModel>> GetLogs(int size)
    {
        var logs = await _energyLogDomainService.GetLogs(size);
        return _mapper.Map<List<EnergyUsageLogViewModel>>(logs);
    }
}
