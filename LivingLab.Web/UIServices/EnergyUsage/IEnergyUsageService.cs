using LivingLab.Web.Models.ViewModels.EnergyUsage;

namespace LivingLab.Web.UIServices.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IEnergyUsageService
{
    Task<List<EnergyUsageViewModel>> GetEnergyUsage(EnergyUsageFilterViewModel filter);
    Task SetLabEnergyBenchmark(EnergyBenchmarkViewModel benchmark);
}
