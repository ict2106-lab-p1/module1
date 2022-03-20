using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Accessory;
using LivingLab.Web.UIServices.Accessory;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
[Route("/Accessory")]
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
        ViewAccessoryViewModel viewAccessories = await _accessoryService.ViewAccessory(accessoryType);
        return View("ViewAccessory", viewAccessories);
    }
    // high level view
    [Route("ViewAccessoryType")]
    public async Task<IActionResult> ViewAccessoryType()
    {
        ViewAccessoryTypeViewModel viewAccessories = await _accessoryService.ViewAccessoryType();
        return View("ViewAccessoryType", viewAccessories);
    }
    
    
    [Route("AddAccessoryDetails")]
    public async Task<AccessoryDetailsViewModel> AddAccessoryDetails()
    { 
        //retrieve data from db
        AccessoryDetailsViewModel accessoryDetails = await _accessoryService.AddAccessoryDetails();
        return accessoryDetails;
    }
    
    [Route("GetEditDetails/{id}")]
    public async Task<AccessoryDetailsViewModel> EditAccessoryDetails(int id)
    { 
        //retrieve data from db
        AccessoryDetailsViewModel accessoryDetails = await _accessoryService.EditAccessoryDetails(id);
        return accessoryDetails;
    }

    [Route("GetDeleteDetails/{id}")]
    public async Task<AccessoryViewModel> GetDeleteDetails(int id)
    {
        AccessoryViewModel accessoryViewModel = await _accessoryService.GetAccessory(id);
        return accessoryViewModel;
    }
    
    [HttpPost("CreateAccessory")]
    public async Task<IActionResult> CreateAccessory(AccessoryDetailsViewModel viewModel)
    {
        await _accessoryService.AddAccessory(viewModel);
        return RedirectToAction("ViewAccessoryType");
    }
    
    [HttpPost("EditAccessory")]
    public async Task<IActionResult> EditAccessory(AccessoryDetailsViewModel viewModel)
    {
        await _accessoryService.EditAccessory(viewModel);
        return RedirectToAction("ViewAccessoryType");
    }
    
    [HttpPost("View/Delete")]
    public async Task<IActionResult> DeleteAccessory(AccessoryViewModel deleteAccessory)
    {
        await _accessoryService.DeleteAccessory(deleteAccessory); 
        
        // Temp - To display ViewAll after editing
        ViewAccessoryViewModel viewAccessory = await _accessoryService.ViewAccessory(deleteAccessory.AccessoryType.Type);
        return View("ViewAccessory", viewAccessory);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
