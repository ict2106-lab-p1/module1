using LivingLab.Core.CsvParser;
using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsage;
using LivingLab.Core.Repositories.Account;
using LivingLab.Core.Repositories.EnergyUsage;

using Microsoft.AspNetCore.Http;

namespace LivingLab.Core.DomainServices.EnergyLog.ManualLog;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class ManualLogDomainService : IManualLogDomainService
{
    private readonly IEnergyUsageLogCsvParser _csvParser;
    private readonly IEnergyUsageRepository _energyUsageRepo;
    private readonly ISessionStatsRepository _sessionStatsRepo;

    public ManualLogDomainService(IEnergyUsageLogCsvParser csvParser, IEnergyUsageRepository energyUsageRepo,
        ISessionStatsRepository sessionStatsRepo)
    {
        _csvParser = csvParser;
        _energyUsageRepo = energyUsageRepo;
        _sessionStatsRepo = sessionStatsRepo;
    }

    public List<EnergyUsageCsvDTO> UploadLogs(IFormFile file)
    {
        return _csvParser.Parse(file).ToList();
    }

    public Task SaveLogs(List<EnergyUsageLog> data, double? fileSizeBytes = null)
    {
        if (fileSizeBytes != null)
        {
            _sessionStatsRepo.LogFileUpload(data.First().Lab.LabId, fileSizeBytes.Value);
        }
        return _energyUsageRepo.BulkInsertAsync(data);
    }
}
