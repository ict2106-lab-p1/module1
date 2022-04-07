using System.Diagnostics;

using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Equipment;
using LivingLab.Web.UIServices.Equipment;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Equipment;

/// <remarks>
/// Author: Team P1-3
/// </remarks>
[Authorize(Roles = "Labtech")]
[Route("Equipment")]
public class EquipmentController : Controller
{
    private readonly ILogger<EquipmentController> _logger;
    private readonly IEquipmentService _equipmentService;

    public EquipmentController(ILogger<EquipmentController> logger, IEquipmentService equipmentService)
    {
        _logger = logger;
        _equipmentService = equipmentService;
    }

    /// <summary>
    /// 1. Call equipment service to get all devices and accessories according to the labLocation eg. NYP-SR7A
    /// </summary>
    /// <param name="labLocation">Lab's location</param>
    /// <returns>EquipmentViewModel</returns>
    [Route("ReviewEquipment/{labLocation}")]
    public async Task<IActionResult> ReviewEquipment(string labLocation)
    {
        EquipmentViewModel equipmentViewModel = await _equipmentService.ViewEquipment(labLocation);
        return View("ReviewEquipment", equipmentViewModel);
    }

    /// <summary>
    /// 1. Call equipment service to update device status according to the labLocation eg. NYP-SR7A
    /// </summary>
    /// <param name="deviceId">device's id</param>
    ///<param name="deviceReviewStatus"> device's review status</param>
    /// <param name="labLocation">lab's location</param>
    /// <returns></returns>
    [HttpPost("UpdateDevice")]
    public IActionResult UpdateDevice(string deviceId, string deviceReviewStatus, string labLocation)
    {
        _equipmentService.UpdateDeviceStatus(deviceId, deviceReviewStatus);
        return Redirect($"ReviewEquipment/{labLocation}#device");
    }

    /// <summary>
    /// 1. Call equipment service to update accessory status according to the labLocation eg. NYP-SR7A
    /// </summary>
    /// <param name="accessoryId">accessory's id</param>
    ///<param name="accessoryReviewStatus">accessory's review status</param>
    /// <param name="labLocation">lab's location</param>
    /// <returns></returns>
    [HttpPost("UpdateAccessory")]
    public IActionResult UpdateAccessory(string accessoryId, string accessoryReviewStatus, string labLocation)
    {
        _equipmentService.UpdateAccessoryStatus(accessoryId, accessoryReviewStatus);
        return Redirect($"ReviewEquipment/{labLocation}#accessory");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
