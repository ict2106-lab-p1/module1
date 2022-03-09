using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.UIServices.Device;

namespace LivingLab.Web.Controllers;

[Route("device")]
public class DeviceController : Controller
{
    private readonly ILogger<DeviceController> _logger;
    private readonly IDeviceService _deviceService;


    public DeviceController(ILogger<DeviceController> logger, IDeviceService deviceService)
    {
        _logger = logger;
        _deviceService = deviceService;
    }

    [Route("view")]
    public async Task<IActionResult> ViewDevice()
    {
        ViewDeviceViewModel viewDevices = await _deviceService.viewDevice();
        return View("ViewDevice", viewDevices);
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
