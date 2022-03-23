using System.Diagnostics;

using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Equipment;
using LivingLab.Web.UIServices.Equipment;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;

[Route("Equipment")]
public class EquipmentController: Controller
{
    private readonly ILogger<EquipmentController> _logger;
    private readonly IEquipmentService _equipmentService;
    
    public EquipmentController(ILogger<EquipmentController> logger, IEquipmentService equipmentService)
    {
        _logger = logger;
        _equipmentService = equipmentService;
    }
    [Route("ReviewEquipment/{labLocation}")]
    public async Task<IActionResult> ReviewEquipment(string labLocation)
    {
        EquipmentViewModel equipmentViewModel = await _equipmentService.ViewEquipment(labLocation);
        return View("ReviewEquipment", equipmentViewModel);
    }

    [HttpPost("UpdateDevice")]
    public IActionResult UpdateDevice(string deviceId, string deviceReviewStatus, string labLocation)
    {
        _equipmentService.UpdateDeviceStatus(deviceId, deviceReviewStatus);
        return Redirect($"ReviewEquipment/{labLocation}#device");
    }
    
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
