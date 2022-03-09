using LivingLab.Core.Entities;

namespace LivingLab.Web.UIServices.EnergyLog;

public interface IEnergyLogService
{
    Task Log(EnergyUsageLog log);
}
