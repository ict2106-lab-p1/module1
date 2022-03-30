
using LivingLab.Web.Models.ViewModels.SessionStats;

namespace LivingLab.Web.UIServices.SessionStats;

public interface ISessionStatsService
{
    
    Task<ViewSessionStatsViewModel> ViewSessionStats();
}
