using AutoMapper;

using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
using LivingLab.Web.Models.ViewModels.EnergyUsage;

namespace LivingLab.Web.UIServices.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageService : IEnergyUsageService
{
    private readonly IMapper _mapper;
    private readonly IEnergyUsageDomainService _energyUsageDomainService;
    
    public EnergyUsageService(IMapper mapper, IEnergyUsageDomainService energyUsageDomainService)
    {
        _mapper = mapper;
        _energyUsageDomainService = energyUsageDomainService;
    }
    
    public Task<List<EnergyUsageViewModel>> GetEnergyUsage(EnergyUsageFilterViewModel filter)
    {
        throw new NotImplementedException();
    }

    public Task SetLabEnergyBenchmark(EnergyBenchmarkViewModel benchmark)
    {
        throw new NotImplementedException();
    }
}
