using AutoMapper;

using LivingLab.Core.DomainServices.EnergyLog.ManualLog;
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

    /// <summary>
    /// 1. Call Manual Log Domain Service to parse uploaded file into a list
    /// 2. Map logs DTO to Log Item ViewModel
    /// 3. Call SaveLogs to insert the logs into database
    /// </summary>
    /// <param name="file"></param>
    /// <returns>Number of logs</returns>
    public async Task<int> UploadLogs(IFormFile file)
    {
        var logs = _manualLogDomainService.UploadLogs(file);
        var logsVM = _mapper.Map<List<EnergyUsageCsvDTO>, List<LogItemViewModel>>(logs);
        await SaveLogs(logsVM, file.Length);
        return logsVM.Count;
    }

    /// <summary>
    /// 1. Map Log Item ViewModel to Energy Usage Log Entity
    /// 2. Call Manual Log Domain Service to bulk insert the list of logs to database
    /// </summary>
    /// <param name="logs, fileSizeBytes"></param>
    public async Task SaveLogs(List<LogItemViewModel> logs, double? fileSizeBytes)
    {
        var data = _mapper.Map<List<LogItemViewModel>, List<EnergyUsageLog>>(logs);
        await _manualLogDomainService.SaveLogs(data, fileSizeBytes);
    }
}
