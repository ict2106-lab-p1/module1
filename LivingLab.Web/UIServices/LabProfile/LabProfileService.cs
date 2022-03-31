using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.Models.ViewModels.UserManagement;
using LivingLab.Web.UIServices.LabProfile;

namespace LivingLab.Web.UIServices.LabProfile;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileService : ILabProfileService
{
    private readonly  IMapper _mapper;
    private readonly ILabProfileDomainService _labProfileDomainService;

    public LabProfileService(ILabProfileDomainService labProfileService, IMapper mapper)
    {
        _labProfileDomainService = labProfileService;
        _mapper = mapper;
    }
    
    public async Task<ViewLabProfileViewModel> GetAllLabAccounts()
    {
        List<Lab> viewLabDtos = await _labProfileDomainService.ViewLabs();
        List<LabProfileViewModel> allLabList =
            _mapper.Map<List<Lab>, List<LabProfileViewModel>>(viewLabDtos);
        ViewLabProfileViewModel labViewModel = new ViewLabProfileViewModel();
        labViewModel.labList = allLabList;
        return labViewModel;
    }

    public async Task<LabProfileViewModel> ViewLabDetails(int id)
    {
        Lab lab = await _labProfileDomainService.ViewLabDetails(id);
        LabProfileViewModel labVM = _mapper.Map<Lab, LabProfileViewModel>(lab);
        return labVM;
    }


    /*Create lab profiles by admins*/
    public async Task<Lab?> NewLab(LabRegisterViewModel labinput)
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
        return await _labProfileDomainService.NewLab(labWrapper);
    }
    
}
