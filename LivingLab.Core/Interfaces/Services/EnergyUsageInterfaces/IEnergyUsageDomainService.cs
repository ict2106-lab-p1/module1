using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;

namespace LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IEnergyUsageDomainService
{
    Task<List<EnergyUsageDTO>> GetEnergyUsage(EnergyUsageFilterDTO filter);
    Task SetLabEnergyBenchmark(EnergyBenchmarkDTO benchmark);
}
