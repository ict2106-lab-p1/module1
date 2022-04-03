using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsage;

using Microsoft.AspNetCore.Http;

namespace LivingLab.Core.DomainServices.EnergyLog;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IManualLogDomainService
{
    List<EnergyUsageCsvDTO> UploadLogs(IFormFile file);
    Task SaveLogs(List<EnergyUsageLog> logs, double? fileSizeBytes);
}
