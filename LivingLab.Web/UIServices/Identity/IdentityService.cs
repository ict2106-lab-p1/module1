using AutoMapper;

using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.UIServices.Identity;

namespace LivingLab.Web.UIServices.Identity;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class IdentityService : IIdentityService
{
    private readonly  IMapper _mapper;
    private readonly IDeviceRepository _deviceRepository;

    public IdentityService(IDeviceRepository deviceRepository, IMapper mapper)
    {
        _deviceRepository = deviceRepository;
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
    
}