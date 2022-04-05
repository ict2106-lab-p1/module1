using AutoMapper;

using LivingLab.Core.DomainServices.Equipment.Device;
using LivingLab.Core.DomainServices.Lab;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.Models.ViewModels.LivingLabDashboard;

namespace LivingLab.Web.UIServices.LivingLabDashboard;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LivingLabDashboardService : ILivingLabDashboardService
{
    private readonly  IMapper _mapper;
    private readonly IDeviceDomainService _deviceDomainService;
    private readonly ILabProfileDomainService _labProfileDomainService;

    public LivingLabDashboardService(IDeviceDomainService deviceDomainService, IMapper mapper,
        ILabProfileDomainService labProfileDomainService)
    {
        _deviceDomainService = deviceDomainService;
        _labProfileDomainService = labProfileDomainService;
        _mapper = mapper;
    }

    public async Task<LivingLabDashboardViewModel> GetAllLabs()
    {
        List<Core.Entities.Lab> labList = await _labProfileDomainService.ViewLabs();

        LivingLabDashboardViewModel viewLabs = new LivingLabDashboardViewModel
        {
            LabList = labList
        };
        return viewLabs;
    }
    
}
