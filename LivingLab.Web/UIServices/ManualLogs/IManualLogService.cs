using LivingLab.Web.Models.ViewModels.EnergyUsage;

namespace LivingLab.Web.UIServices.ManualLogs;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IManualLogService
{
    Task<int> UploadLogs(IFormFile file);

    Task SaveLogs(List<LogItemViewModel> logs, double? fileSizeBytes = null);
}
