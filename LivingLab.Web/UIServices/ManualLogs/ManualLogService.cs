using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;

using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.EnergyUsage;

namespace LivingLab.Web.UIServices.ManualLogs;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class ManualLogService : IManualLogService
{
    private readonly IMapper _mapper;
    private readonly IManualLogDomainService _manualLogDomainService;
    
    public ManualLogService(IMapper mapper, IManualLogDomainService manualLogDomainService)
    {
        _mapper = mapper;
        _manualLogDomainService = manualLogDomainService;
    }
    
    public List<LogItemViewModel> UploadLogs(IFormFile file)
    {
        var logs = _manualLogDomainService.UploadLogs(file);
        return _mapper.Map<List<EnergyUsageCsvDTO>, List<LogItemViewModel>>(logs);
    }

    public async Task SaveLogs(List<LogItemViewModel> logs)
    {
        var data = _mapper.Map<List<LogItemViewModel>, List<EnergyUsageLog>>(logs);
        await _manualLogDomainService.SaveLogs(data);
    }
}
