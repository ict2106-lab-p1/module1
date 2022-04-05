
using LivingLab.Web.Models.ViewModels.SessionStats;

namespace LivingLab.Web.UIServices.SessionStats;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface ISessionStatsService
{
    Task<ViewSessionStatsViewModel> ViewSessionStats(string labLocation);
}
