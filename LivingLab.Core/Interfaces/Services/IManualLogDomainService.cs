using LivingLab.Core.Entities;
using LivingLab.Core.Models;

using Microsoft.AspNetCore.Http;

namespace LivingLab.Core.Interfaces.Services;

public interface IManualLogDomainService
{
    List<EnergyUsageCsvModel> UploadLogs(IFormFile file);
    Task SaveLogs(List<EnergyUsageLog> logs);
}
