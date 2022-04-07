using LivingLab.Web.Models.DTOs;
using LivingLab.Web.Models.ViewModels.EnergyUsage;

namespace LivingLab.Web.UIServices.EnergyLog;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IEnergyLogService
{
    Task Log(EnergyUsageLogDTO log);
    Task<List<EnergyUsageLogViewModel>> GetLogs(int size);
}
