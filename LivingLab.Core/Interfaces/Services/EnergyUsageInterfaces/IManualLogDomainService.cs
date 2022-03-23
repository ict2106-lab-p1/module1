using LivingLab.Core.Entities;
using LivingLab.Core.Models;

using Microsoft.AspNetCore.Http;

namespace LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IManualLogDomainService
{
    List<EnergyUsageCsvModel> UploadLogs(IFormFile file);
    Task SaveLogs(List<EnergyUsageLog> logs);
}
