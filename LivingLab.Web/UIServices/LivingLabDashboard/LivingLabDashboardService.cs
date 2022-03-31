using AutoMapper;

using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.Models.ViewModels.LivingLabDashboard;
using LivingLab.Web.UIServices.LabBooking;
using LivingLab.Web.UIServices.LabProfile;

namespace LivingLab.Web.UIServices.LivingLabDashboard;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LivingLabDashboardService : ILivingLabDashboardService
{
    private readonly  IMapper _mapper;
    private readonly IDeviceRepository _deviceRepository;
    private readonly ILabRepository _labRepository;

    public LivingLabDashboardService(IDeviceRepository deviceRepository, IMapper mapper, ILabRepository labRepository)
    {
        _deviceRepository = deviceRepository;
        _labRepository = labRepository;
        _mapper = mapper;
    }

    public async Task<ViewDeviceViewModel> viewDevice()
    {
        //retrieve data from db
        List<Core.Entities.Device> deviceList = await _deviceRepository.GetAllAsync();
                
        //map entity model to view model
        List<DeviceViewModel> devices = _mapper.Map<List<Core.Entities.Device>, List<DeviceViewModel>> (deviceList);
            
        //add list of device view model to the view device view model
        ViewDeviceViewModel viewDevices = new ViewDeviceViewModel();
        viewDevices.DeviceList = devices;
        return viewDevices;
    }
    
    public async Task<LivingLabDashboardViewModel> GetAllLabs()
    {
        List<Core.Entities.Lab> labList = await _labRepository.GetAllLabs();
        Console.WriteLine("test");

        LivingLabDashboardViewModel viewLabs = new LivingLabDashboardViewModel
        {
            LabList = labList
        };
        return viewLabs;
    }
    
}
