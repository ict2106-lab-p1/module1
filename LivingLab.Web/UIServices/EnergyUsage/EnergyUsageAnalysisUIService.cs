using AutoMapper;

using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageAnalysis;
using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsage;
using LivingLab.Web.Models.ViewModels.EnergyUsage;
using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.UIServices.LabProfile;

namespace LivingLab.Web.UIServices.EnergyUsage;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class EnergyUsageAnalysisUIService : IEnergyUsageAnalysisUIService 
{
    private readonly IMapper _mapper;
    private readonly IEnergyUsageAnalysisService _analysis;
    private readonly ILabProfileService _labProfileService;

    public EnergyUsageAnalysisUIService(IMapper mapper, IEnergyUsageAnalysisService analysis, ILabProfileService labProfileService)
    {
        _mapper = mapper;
        _analysis = analysis;
        _labProfileService = labProfileService;
    }
    public byte[] Export(List<DeviceEnergyUsageDTO> content)
    {
        return _analysis.ExportDeviceEU(content);
    }
    public List<DeviceEnergyUsageDTO> GetDeviceEnergyUsageByDate(DateTime start, DateTime end)
    {
        return _analysis.GetDeviceEnergyUsageByDate(start,end);
    }
    public List<LabEnergyUsageDTO> GetLabEnergyUsageByDate(DateTime start, DateTime end)
    {
        return _analysis.GetLabEnergyUsageByDate(start,end);
    }
    // joey
    // may nee to change to ENergyUsageFilterDto
    // public List<TopSevenLabEnergyUsageDTO> GetTopSevenLabEnergyUsage(DateTime start, DateTime end)
    // {
    //     throw new NotImplementedException();
    // }
    // public List<MonthlyEnergyUsageDTO> GetEnergyUsageTrendAllLab(DateTime start, DateTime end)
    // {
    //     throw new NotImplementedException();
    // }
    // public List<IndividualLabMonthlyEnergyUsageDTO> GetEnergyUsageTrendSelectedLab(DateTime start, DateTime end, int labId)
    // {
    //     throw new NotImplementedException();
    // }
    
    public async Task<TopSevenLabEnergyUsageDTO> GetTopSevenLabEnergyUsage(DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }

    public Task<MonthlyEnergyUsageDTO> GetEnergyUsageTrendAllLab(DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }

    public async Task<EnergyUsageTrendAllLabViewModel> GetEnergyUsageTrendAllLab(EnergyUsageFilterViewModel filter, int labId)
    {
        throw new NotImplementedException();
    }
    public async Task<EnergyUsageTrendSelectedLabViewModel> GetEnergyUsageTrendSelectedLab(EnergyUsageFilterViewModel filter)
    {
        var energyUsageFilter = _mapper.Map<EnergyUsageFilterViewModel, EnergyUsageFilterDTO>(filter);
        var logs = await _analysis.GetEnergyUsageTrendSelectedLab(energyUsageFilter);
        return _mapper.Map<IndividualLabMonthlyEnergyUsageDTO, EnergyUsageTrendSelectedLabViewModel>(logs);

    }
    
    public async Task<EnergyUsageTrendAllLabViewModel> GetEnergyUsageTrendAllLab(EnergyUsageFilterViewModel filter)
    {
        var energyUsageFilter = _mapper.Map<EnergyUsageFilterViewModel, EnergyUsageFilterDTO>(filter);
        var logs = await _analysis.GetEnergyUsageTrendAllLab(energyUsageFilter);
        return _mapper.Map<MonthlyEnergyUsageDTO, EnergyUsageTrendAllLabViewModel>(logs);

    }
    
    // JOEY ADDED
    public async Task<EnergyBenchmarkViewModel> GetLabEnergyBenchmark(int labId)
    {
        var data = await _analysis.GetLabEnergyBenchmark(labId);
        return _mapper.Map<Lab, EnergyBenchmarkViewModel>(data);
    }
    
    public Task<List<LabInformationModel>?> GetAllLabs()
    {
        return _labProfileService.GetAllLabAccounts(); 
    }

    // weijie
    // not sure what will be your DTO looks like may have to create in LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
    public List<DeviceInLabDTO> GetEnergyUsageLabDistribution(DateTime start, DateTime end, string deviceType)
    {
        throw new NotImplementedException();
    }
    public List<DeviceInLabDTO> GetEnergyUsageDeviceDistribution(DateTime start, DateTime end, int labID)
    {
        throw new NotImplementedException();
    }
}
