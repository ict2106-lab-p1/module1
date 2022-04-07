using System.Diagnostics;

using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.UIServices.Device;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Equipment;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
[Authorize(Roles = "Labtech")]
[Route("/Device")]
public class DeviceController : Controller
{
    private readonly ILogger<DeviceController> _logger;
    private readonly IDeviceService _deviceService;
    private readonly UserManager<ApplicationUser> _userManager;
    public DeviceController(ILogger<DeviceController> logger, IDeviceService deviceService, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _deviceService = deviceService;
        _userManager = userManager;
    }

    /// <summary>
    /// 1. Call device service to get all devices according to the labLocation eg. NYP-SR7A and devices type chosen
    /// </summary>
    /// <param name="labLocation">lab's location</param>
    /// <returns>ViewDeviceTypeViewModel</returns>
    [Route("ViewType/{labLocation}")]
    public async Task<IActionResult> ViewType(string labLocation)
    {
        ViewDeviceTypeViewModel viewDeviceTypeViewModel = await _deviceService.ViewDeviceType(labLocation);
        return View("ViewDeviceType", viewDeviceTypeViewModel);
    }

    /// <summary>
    /// 1. Call device service to get all devices type according to the labLocation eg. NYP-SR7A
    /// </summary>
    /// <param name="deviceType">device's type</param>
    /// <param name="labLocation">lab's location</param>
    /// <returns>ViewDeviceViewModel</returns>
    [HttpPost("View")]
    public async Task<IActionResult> ViewAll(string deviceType, string labLocation)
    {
        ViewDeviceViewModel viewDevices = await _deviceService.ViewDevice(deviceType, labLocation);
        return View("ViewDevice", viewDevices);
    }

    /// <summary>
    /// 1. Call device service to get all devices details based on device Id
    /// </summary>
    /// <param name="id">device's id</param>
    /// <returns>DeviceViewModel</returns>
    [Route("View/{id}")]
    public async Task<DeviceViewModel> ViewDeviceDetails(int id)
    {
        //retrieve data from db
        DeviceViewModel device = await _deviceService.ViewDeviceDetails(id);

        return device;
    }

    /// <summary>
    /// 1. Call device service to add a device to db
    /// </summary>
    /// <returns>AddDeviceViewModel</returns>
    [Route("ViewAddDetails")]
    public async Task<AddDeviceViewModel> ViewAddDetails()
    {
        //retrieve data from db
        AddDeviceViewModel device = await _deviceService.ViewAddDetails();

        return device;
    }

    /// <summary>
    /// 1. Call device service to edit a device to db and display ViewAll after editing
    /// </summary>
    /// <param name="editedDevice">device's view model</param>
    /// <returns>ViewDeviceViewModel</returns>
    [HttpPost("View/Edit")]
    public async Task<IActionResult> EditDevice(DeviceViewModel editedDevice)
    {
        Console.WriteLine("DEVID: " + editedDevice.Id);
        Console.WriteLine("DEVTYPE: " + editedDevice.Type);
        await _deviceService.EditDevice(editedDevice);

        // Temp - To display ViewAll after editing
        ViewDeviceViewModel viewDevices = await _deviceService.ViewDevice(editedDevice.Type, editedDevice.Lab.LabLocation);
        return View("ViewDevice", viewDevices);
    }

    /// <summary>
    /// 1. Call device service to request approval for addition of devices using email
    /// </summary>
    /// <param name="addedDevice">add device's view model</param>
    /// <returns>device type page</returns>
    [HttpGet]
    [HttpPost("ViewAdd")]
    public async Task<IActionResult> AddDevice(AddDeviceViewModel addedDevice)
    {
        await _deviceService.AddDevice(addedDevice);
        ViewDeviceViewModel viewDevices = await _deviceService.ViewDevice(addedDevice.Device.Type, addedDevice.Device.Lab.LabLocation);

        // Send email to labTech in charge for approval
        string scheme = this.Request.Scheme;
        if (Url.IsLocalUrl(Request.Headers["Referer"].ToString()))
        {
            HttpContext.Request.Host = HostString.FromUriComponent("livinglab.amatsuka.me");
        }
        string url = scheme + "://" + HttpContext.Request.Host;

        var user = await _userManager.GetUserAsync(User);
        await _deviceService.SendReviewerEmail(url, addedDevice.Device.Lab.LabLocation, user);

        return Redirect($"ViewType/{addedDevice.Device.Lab.LabLocation}");
    }
    /// <summary>
    /// 1. Delete device based on device Id
    /// </summary>
    /// <param name="deleteDevice">delete device's view model</param>
    /// <returns>ViewDeviceViewModel</returns>
    [HttpPost("View/Delete")]
    public async Task<IActionResult> DeleteDevice(DeviceViewModel deleteDevice)
    {
        await _deviceService.DeleteDevice(deleteDevice);

        // Temp - To display ViewAll after editing
        ViewDeviceViewModel viewDevices = await _deviceService.ViewDevice(deleteDevice.Type, deleteDevice.Lab.LabLocation);
        return View("ViewDevice", viewDevices);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
