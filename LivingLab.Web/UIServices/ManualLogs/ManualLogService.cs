using AutoMapper;

using LivingLab.Core.DomainServices.EnergyLog;
using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsage;
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

    public async Task<int> UploadLogs(IFormFile file)
    {
        var logs = _manualLogDomainService.UploadLogs(file);
        var logsVM = _mapper.Map<List<EnergyUsageCsvDTO>, List<LogItemViewModel>>(logs);
        await SaveLogs(logsVM, file.Length);
        return logsVM.Count;
    }

    public async Task SaveLogs(List<LogItemViewModel> logs, double? fileSizeBytes)
    {
        var data = _mapper.Map<List<LogItemViewModel>, List<EnergyUsageLog>>(logs);
        await _manualLogDomainService.SaveLogs(data, fileSizeBytes);
    }
}
