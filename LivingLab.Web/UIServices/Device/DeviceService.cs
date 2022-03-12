using AutoMapper;

using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.UIServices.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class DeviceService : IDeviceService
{
    private readonly  IMapper _mapper;
    private readonly IDeviceDomainService _deviceDomainService;

    public DeviceService(IDeviceDomainService deviceService, IMapper mapper)
    {
        _deviceDomainService = deviceService;
        _mapper = mapper;
    }

    public async Task<ViewDeviceViewModel> ViewDevice(string deviceType)
    {
        //retrieve data from db
        List<Core.Entities.Device> deviceList = await _deviceDomainService.ViewDevice(deviceType);
                
        //map entity model to view model
        List<DeviceViewModel> devices = _mapper.Map<List<Core.Entities.Device>, List<DeviceViewModel>> (deviceList);
            
        //add list of device view model to the view device view model
        ViewDeviceViewModel viewDevices = new ViewDeviceViewModel();
        viewDevices.DeviceList = devices;
        return viewDevices;
    }

    public async Task<ViewDeviceTypeViewModel> ViewDeviceType()
    {
        List<ViewDeviceTypeDTO> viewDeviceTypeDtos = await _deviceDomainService.ViewDeviceType();
        //map viewDeviceTypeDto to deviceTypeViewModel
        List<DeviceTypeViewModel> deviceList =
            _mapper.Map<List<ViewDeviceTypeDTO>, List<DeviceTypeViewModel>>(viewDeviceTypeDtos);
        ViewDeviceTypeViewModel deviceTypeViewModel = new ViewDeviceTypeViewModel();
        deviceTypeViewModel.ViewDeviceTypeDtos = deviceList;
        return deviceTypeViewModel;
    }
    
    public async Task<DeviceViewModel> ViewDeviceDetails(int id)
    {
        //retrieve data from db
        Core.Entities.Device device = await _deviceDomainService.ViewDeviceDetails(id);
        DeviceViewModel deviceVM = _mapper.Map<Core.Entities.Device, DeviceViewModel> (device);
        return deviceVM;
    }
    
    public async Task<DeviceViewModel> EditDevice(int id, String serialNo, String name, String type, String desc, String status, Double threshold)
    {
        //retrieve data from db
        DeviceViewModel editDeviceVM = new DeviceViewModel {
            Id = id, 
            SerialNo = serialNo, 
            Name = name, 
            Type = type,
            Description = desc,
            Status = status,
            Threshold = threshold
        };
        Core.Entities.Device editDevice = _mapper.Map<DeviceViewModel, Core.Entities.Device> (editDeviceVM);
        await _deviceDomainService.EditDeviceDetails(editDevice);
        
        return editDeviceVM;
    }
    
}
