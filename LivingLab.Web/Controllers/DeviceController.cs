using System.Diagnostics;

using LivingLab.Web.ViewModels;

using LivingLab.Domain.Entities;
using LivingLab.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace LivingLab.Web.Controllers;

[Route("device")]
public class DeviceController : Controller
{
    private readonly ILogger<DeviceController> _logger;
    private readonly  IMapper _mapper;
    private readonly IDeviceRepository _deviceRepository;


    public DeviceController(ILogger<DeviceController> logger, IMapper mapper, IDeviceRepository deviceRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _deviceRepository = deviceRepository;
    }

    [Route("view")]
    public async Task<IActionResult> ViewDevice()
    { 
        //retrieve data from db
        List<Device> deviceList = await _deviceRepository.GetDeviceWithDeviceType();
        
        //map entity model to view model
        List<DeviceViewModel> devices = _mapper.Map<List<Device>, List<DeviceViewModel>> (deviceList);
        
        //add list of device view model to the view device view model
        ViewDeviceViewModel viewDevices = new ViewDeviceViewModel();
        viewDevices.DeviceList = devices;
        return View("ViewDevice", viewDevices);
    }
    
    [Route("view/{id}")]
    public async Task<IActionResult> EditDevice(int id)
    { 
        //retrieve data from db
        Device device = await _deviceRepository.GetDeviceDetails(id);
        DeviceViewModel Device = _mapper.Map<Device, DeviceViewModel> (device);
        Console.WriteLine(Device.Id);
        Console.WriteLine(Device.DeviceType.Name);
        Console.WriteLine(Device.DeviceType.Description);
        Console.WriteLine(Device.DeviceType.Cost);
        Console.WriteLine(Device.SerialNo);
        

        return View("DeviceDetails", Device);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Device> deviceList = await _deviceRepository.GetDeviceWithDeviceType();
        return Ok(deviceList);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
