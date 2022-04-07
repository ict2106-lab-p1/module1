using LivingLab.Core.Entities.DTO.EnergyUsage;
using LivingLab.Core.Entities.DTO.Lab;

namespace LivingLab.Core.DomainServices.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IEnergyUsageDomainService
{
    Task<EnergyUsageDTO> GetEnergyUsage(EnergyUsageFilterDTO filter);
    Task<LabDetailsDTO> GetLabEnergyBenchmark(int labId);
    Task SetLabEnergyBenchmark(Entities.Lab lab);
}

