using AutoMapper;

using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.UIServices.Device;

public class DeviceService : IDeviceService
{
    private readonly  IMapper _mapper;
    private readonly IDeviceRepository _deviceRepository;

    public DeviceService(IDeviceRepository deviceRepository, IMapper mapper)
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
