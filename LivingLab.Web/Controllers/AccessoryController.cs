using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Accessory;
using LivingLab.Web.UIServices.Accessory;
using LivingLab.Web.UIServices.Device;

namespace LivingLab.Web.Controllers;

[Route("accessory")]
public class AccessoryController : Controller
{
    private readonly ILogger<AccessoryController> _logger;
    private readonly IAccessoryService _accessoryService;

    public AccessoryController(ILogger<AccessoryController> logger, IAccessoryService accessoryService)
    {
        _logger = logger;
        _accessoryService = accessoryService;
    }

    [Route("view")]
    public async Task<IActionResult> ViewAccessory()
    {
        ViewAccessoryViewModel viewAccessories = await _accessoryService.viewAccessory();
        return View("ViewAccessory", viewAccessories);
    }

    // [HttpGet]
    // public async Task<IActionResult> GetAll()
    // {
    //     List<Accessory> accessoryList = await _accessoryRepository.GetAccessoryWithAccessoryType();
    //     return Ok(accessoryList);
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
