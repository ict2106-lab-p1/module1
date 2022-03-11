using LivingLab.Core.Entities;

namespace LivingLab.Web.UIServices.EnergyLog;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IEnergyLogService
{
    Task Log(EnergyUsageLog log);
}
