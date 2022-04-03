using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
using LivingLab.Web.Models.ViewModels.EnergyUsage;
using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.UIServices.LabProfile;

namespace LivingLab.Web.UIServices.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageService : IEnergyUsageService
{
    private readonly IMapper _mapper;
    private readonly IEnergyUsageDomainService _energyUsageDomainService;
    private readonly ILabProfileService _labProfileService;

    public EnergyUsageService(IMapper mapper, IEnergyUsageDomainService energyUsageDomainService, ILabProfileService labProfileService)
    {
        _mapper = mapper;
        _energyUsageDomainService = energyUsageDomainService;
        _labProfileService = labProfileService;
    }

    public async Task<EnergyUsageViewModel> GetEnergyUsage(EnergyUsageFilterViewModel filter)
    {
        var energyUsageFilter = _mapper.Map<EnergyUsageFilterViewModel, EnergyUsageFilterDTO>(filter);
        var logs = await _energyUsageDomainService.GetEnergyUsage(energyUsageFilter);
        return _mapper.Map<EnergyUsageDTO, EnergyUsageViewModel>(logs);
    }

    public async Task<EnergyBenchmarkViewModel> GetLabEnergyBenchmark(int labId)
    {
        var data = await _energyUsageDomainService.GetLabEnergyBenchmark(labId);
        return _mapper.Map<Lab, EnergyBenchmarkViewModel>(data);
    }

    public Task SetLabEnergyBenchmark(EnergyBenchmarkViewModel benchmark)
    {
        var lab = _mapper.Map<EnergyBenchmarkViewModel, Lab>(benchmark);
        return _energyUsageDomainService.SetLabEnergyBenchmark(lab);
    }

    public Task<List<LabInformationModel>?> GetAllLabs()
    {
        return _labProfileService.GetAllLabAccounts();
    }
}
