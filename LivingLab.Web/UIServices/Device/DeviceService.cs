using System.Security.Policy;

using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Device;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Web.Models.ViewModels.Device;

using Microsoft.AspNetCore.Identity;

namespace LivingLab.Web.UIServices.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class DeviceService : IDeviceService
{
    private readonly IMapper _mapper;
    private readonly ILogger<DeviceService> _logger;
    private readonly IDeviceDomainService _deviceDomainService;
    private readonly IEmailSender _emailSender;
    private readonly ILabProfileDomainService _labProfileDomainService;
    private readonly UserManager<ApplicationUser> _userManager;

    public DeviceService(IMapper mapper, ILogger<DeviceService> logger,IDeviceDomainService deviceService, IEmailSender emailSender,ILabProfileDomainService labProfileDomainService, UserManager<ApplicationUser> userManager)
    {
        _mapper = mapper;
        _logger = logger;
        _deviceDomainService = deviceService;
        _emailSender = emailSender;
        _labProfileDomainService = labProfileDomainService;
        _userManager = userManager;
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
    
    // Send email to request approval for add device/accessory to lab in charge
    public async Task<bool> SendReviewerEmail(string url)
    {
        try
        {
            var labTech = await _userManager.GetUsersInRoleAsync("labtech");
            var labs = await _labProfileDomainService.ViewLabs();
            foreach(ApplicationUser lt in labTech)
            {
                foreach(Lab lab in labs)
                    if (lab.LabInCharge.Contains(lt.Id))
                    {
                        var link = url + "/Equipment/ReviewEquipment/" + lab.LabLocation;
                        var msg = "<h3>["+ lab.LabLocation + "]<br> New Device/Accessory Added</h3>" +
                                  "Hi " + lt.FirstName + ",<br>" +
                                  "There is a new device/accessory added to <b>" + lab.LabLocation + "</b> that requires your review. <br>" +
                                  "Please click <a href='"+ link + "'>here</a> " +
                                  " to approve/decline, and to view other pending review requests.</br>";
                        await _emailSender.SendEmailAsync(lt.Email, "New Device/Accessory Review Requested", msg);
                        _logger.LogInformation("Email sent to labTech in charge");
                    }
                    else
                    {
                        _logger.LogInformation("LabTech in charge not found. Email not sent.");
                        return false;
                    }
            }
            return true;
        }
        catch (Exception)
        {
            _logger.LogInformation("Exception caught. Email not sent. ");
            return false;
        }
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
