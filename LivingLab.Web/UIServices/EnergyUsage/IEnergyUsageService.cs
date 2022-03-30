using LivingLab.Web.Models.ViewModels.EnergyUsage;

namespace LivingLab.Web.UIServices.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IEnergyUsageService
{
    Task<EnergyUsageViewModel> GetEnergyUsage(EnergyUsageFilterViewModel filter);
    Task<EnergyBenchmarkViewModel> GetLabEnergyBenchmark(int labId);
    Task SetLabEnergyBenchmark(EnergyBenchmarkViewModel benchmark);
}
