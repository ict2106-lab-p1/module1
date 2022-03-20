using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;

namespace LivingLab.Core.DomainServices.EnergyUsageServices;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageDomainService : IEnergyUsageDomainService
{
    private readonly ILabRepository _lapRepository;
    private readonly IEnergyUsageRepository _energyUsageRepository;
    
    public EnergyUsageDomainService(ILabRepository lapRepository, IEnergyUsageRepository energyUsageRepository)
    {
        _lapRepository = lapRepository;
        _energyUsageRepository = energyUsageRepository;
    }
    
    public Task<List<EnergyUsageDTO>> GetEnergyUsage(EnergyUsageFilterDTO filter)
    {
        throw new NotImplementedException();
    }

    public Task SetLabEnergyBenchmark(EnergyBenchmarkDTO benchmark)
    {
        throw new NotImplementedException();
    }
}
