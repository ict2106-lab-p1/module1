using AutoMapper;

using LivingLab.Core.Entities.DTO.Device;
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

    public async Task<ViewDeviceViewModel> ViewDevice(string deviceType, string labLocation)
    {
        //retrieve data from db
        List<Core.Entities.Device> deviceList = await _deviceDomainService.ViewDevice(deviceType, labLocation);
                
        //map entity model to view model
        List<DeviceViewModel> devices = _mapper.Map<List<Core.Entities.Device>, List<DeviceViewModel>> (deviceList);
            
        //add list of device view model to the view device view model
        ViewDeviceViewModel viewDevices = new ViewDeviceViewModel();
        viewDevices.DeviceList = devices;
        return viewDevices;
    }

    public async Task<ViewDeviceTypeViewModel> ViewDeviceType(string labLocation)
    {
        List<ViewDeviceTypeDTO> viewDeviceTypeDtos = await _deviceDomainService.ViewDeviceType(labLocation);
        //map viewDeviceTypeDto to deviceTypeViewModel
        List<DeviceTypeViewModel> deviceList =
            _mapper.Map<List<ViewDeviceTypeDTO>, List<DeviceTypeViewModel>>(viewDeviceTypeDtos);
        ViewDeviceTypeViewModel deviceTypeViewModel = new ViewDeviceTypeViewModel();
        deviceTypeViewModel.ViewDeviceTypeDtos = deviceList;
        deviceTypeViewModel.labLocation = labLocation;
        return deviceTypeViewModel;
    }
    
    public async Task<DeviceViewModel> ViewDeviceDetails(int id)
    {
        //retrieve data from db
        Core.Entities.Device device = await _deviceDomainService.ViewDeviceDetails(id);
        DeviceViewModel deviceVM = _mapper.Map<Core.Entities.Device, DeviceViewModel> (device);
        return deviceVM;
    }
    
    public async Task<DeviceViewModel> AddDevice(DeviceViewModel deviceViewModel)
    {
        //retrieve data from db
        Core.Entities.Device addDevice = _mapper.Map<DeviceViewModel, Core.Entities.Device> (deviceViewModel);
        await _deviceDomainService.AddDevice(addDevice);
        return deviceViewModel;
    }
    
    public async Task<DeviceViewModel> ViewAddDetails()
    {
        //retrieve data from db
        Core.Entities.Device device = await _deviceDomainService.GetDeviceLastRow();
        DeviceViewModel deviceVM = _mapper.Map<Core.Entities.Device, DeviceViewModel> (device);
        return deviceVM;
    }
    
    
    public async Task<DeviceViewModel> EditDevice(DeviceViewModel deviceViewModel)
    {
        //retrieve data from db
        Core.Entities.Device editDevice = _mapper.Map<DeviceViewModel, Core.Entities.Device> (deviceViewModel);
        await _deviceDomainService.EditDeviceDetails(editDevice);
        
        return deviceViewModel;
    }
    
    public async Task<DeviceViewModel> DeleteDevice(DeviceViewModel deviceViewModel)
    {
        //retrieve data from db
        Core.Entities.Device deleteDevice = _mapper.Map<DeviceViewModel, Core.Entities.Device> (deviceViewModel);
        await _deviceDomainService.DeleteDevice(deleteDevice);
        
        return deviceViewModel;
    }
    
}
