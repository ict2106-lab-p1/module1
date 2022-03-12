using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.UIServices.Device;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
[Route("Device")]
public class DeviceController : Controller
{
    private readonly ILogger<DeviceController> _logger;
    private readonly IDeviceService _deviceService;


    public DeviceController(ILogger<DeviceController> logger, IDeviceService deviceService)
    {
        _logger = logger;
        _deviceService = deviceService;
    }

    [HttpPost("ViewAll")]
    public async Task<IActionResult> ViewAll(string deviceType)
    {
        ViewDeviceViewModel viewDevices = await _deviceService.ViewDevice(deviceType);
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

    [Route("ViewType")]
    public async Task<IActionResult> ViewType()
    {
        ViewDeviceTypeViewModel viewDeviceTypeViewModel = await _deviceService.ViewDeviceType();
        return View("ViewDeviceType", viewDeviceTypeViewModel);
    }

    // [HttpGet]
    // public async Task<IActionResult> GetAll()
    // {
    //     List<Device> deviceList = await _deviceRepository.GetAllAsync();
    //     return Ok(deviceList);
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
