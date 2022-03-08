using System.Diagnostics;

using LivingLab.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.UIServices.Device;

namespace LivingLab.Web.Controllers;

[Route("Accessory")]
public class AccessoryController : Controller
{
    private readonly ILogger<AccessoryController> _logger;
    private readonly IAccessoryService _accessoryService;

    public AccessoryController(ILogger<AccessoryController> logger, IAccessoryService accessoryService)
    {
        _logger = logger;
        _accessoryService = accessoryService;
    }

    // detailed view
    [HttpPost("ViewAccessory")]
    public async Task<IActionResult> ViewAccessory(string accessoryType)
    {
        ViewAccessoryViewModel viewAccessories = await _accessoryService.viewAccessory(accessoryType);
        return View("ViewAccessory", viewAccessories);
    }
    
    // high level view
    [Route("ViewAccessoryType")]
    public async Task<IActionResult> ViewAccessoryType()
    {
        AccessoryTypeViewModel viewAccessories = await _accessoryService.viewAccessoryType();
        return View("ViewAccessoryType", viewAccessories);
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
