using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.UIServices.LabProfile;

namespace LivingLab.Web.UIServices.LabProfile;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileService : ILabProfileService
{
    private readonly  IMapper _mapper;
    private readonly ILabProfileDomainService _labProf;

    public LabProfileService(ILabProfileDomainService labProf, IMapper mapper)
    {
        _labProf = labProf;
        _mapper = mapper;
    }

    public async Task<Lab?> NewLab(LabProfileViewModel labinput)
    {
        var labWrapper = new Lab
        {
            LabLocation = labinput.LabLocation,
            LabStatus = labinput.LabStatus,
            LabInCharge = labinput.LabInCharge,
            Area = labinput.Area,
            Capacity = labinput.Capacity,
            EnergyUsageBenchmark = labinput.EnergyUsageBenchmark
        };
        return await _labProf.NewLab(labWrapper);
    }
    
}
