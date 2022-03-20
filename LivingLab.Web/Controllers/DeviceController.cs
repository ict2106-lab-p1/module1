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

    [Route("ViewType")]
    public async Task<IActionResult> ViewType()
    {
        ViewDeviceTypeViewModel viewDeviceTypeViewModel = await _deviceService.ViewDeviceType();
        return View("ViewDeviceType", viewDeviceTypeViewModel);
    }
    [HttpPost("View")]
    public async Task<IActionResult> ViewAll(string deviceType)
    {
        ViewDeviceViewModel viewDevices = await _deviceService.ViewDevice(deviceType);
        return View("ViewDevice", viewDevices);
    }


    [Route("View/{id}")]
    public async Task<DeviceViewModel> ViewDeviceDetails(int id)
    {
        //retrieve data from db
        DeviceViewModel device = await _deviceService.ViewDeviceDetails(id);

        return device;
        // return View("_DeviceDetails", device);
    }

    [Route("ViewAddDetails")]
    public async Task<DeviceViewModel> ViewAddDetails()
    {
        //retrieve data from db
        DeviceViewModel device = await _deviceService.ViewAddDetails();

        return device;
        // return View("_DeviceDetails", device);
    }

    [HttpPost("View/Edit")]
    public async Task<IActionResult> EditDevice(DeviceViewModel editedDevice)
    {
        Console.WriteLine("DEVID: " + editedDevice.Id);
        Console.WriteLine("DEVTYPE: " + editedDevice.Type);
        await _deviceService.EditDevice(editedDevice);

        // Temp - To display ViewAll after editing
        ViewDeviceViewModel viewDevices = await _deviceService.ViewDevice(editedDevice.Type);
        return View("ViewDevice", viewDevices);
    }
    [HttpPost("View/Add")]
    public async Task<IActionResult> AddDevice(DeviceViewModel addedDevice)
    {
        await _deviceService.AddDevice(addedDevice);
        ViewDeviceViewModel viewDevices = await _deviceService.ViewDevice(addedDevice.Type);
        return View("ViewDevice", viewDevices);
    }

    [HttpPost("View/Delete")]
    public async Task<IActionResult> DeleteDevice(DeviceViewModel deleteDevice)
    {
        await _deviceService.DeleteDevice(deleteDevice);

        // Temp - To display ViewAll after editing
        ViewDeviceViewModel viewDevices = await _deviceService.ViewDevice(deleteDevice.Type);
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
