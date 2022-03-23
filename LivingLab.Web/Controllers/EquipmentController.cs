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
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
