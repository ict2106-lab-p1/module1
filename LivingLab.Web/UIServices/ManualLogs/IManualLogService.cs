using LivingLab.Web.Models.ViewModels;

namespace LivingLab.Web.UIServices.ManualLogs;

public interface IManualLogService
{
    List<LogItemViewModel> UploadLogs(IFormFile file);
    Task SaveLogs(List<LogItemViewModel> logs);
}
