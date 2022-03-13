using System.Diagnostics;

using LivingLab.Core.Entities;

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

    [Route("View")]
    public async Task<IActionResult> ViewAll(string deviceType)
    {
        ViewDeviceViewModel viewDevices = await _deviceService.ViewDevice(deviceType);
        return View("ViewDevice", viewDevices);
    }
    
    [Route("View/{id}")]
    public async Task<IActionResult> ViewDeviceDetails(int id)
    { 
        //retrieve data from db
        DeviceViewModel device = await _deviceService.ViewDeviceDetails(id);

        return View("DeviceDetails", device);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditDevice(DeviceViewModel deviceViewModel)
    {
        Console.WriteLine("id: " + deviceViewModel.Id);
        Console.WriteLine("serialNo: " + deviceViewModel.SerialNo);
        Console.WriteLine("name: " + deviceViewModel.Name);
        Console.WriteLine("type: " + deviceViewModel.Type);
        Console.WriteLine("desc: " + deviceViewModel.Description);
        Console.WriteLine("status: " + deviceViewModel.Status);
        Console.WriteLine("threshold: " + deviceViewModel.Threshold);
        await _deviceService.EditDevice(deviceViewModel);
        
        // Temp - To display ViewAll after editing
        ViewDeviceViewModel viewDevices = await _deviceService.ViewDevice(deviceViewModel.Type);
        return View("ViewDevice", viewDevices);
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
