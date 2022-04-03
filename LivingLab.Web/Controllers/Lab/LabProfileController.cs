using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Controllers.Api;
using LivingLab.Web.UIServices.UserManagement;
using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.UIServices.Account;
using LivingLab.Web.UIServices.LabProfile;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
[Route("LabProfile")]
public class LabProfileController: Controller
{
    private readonly ILabProfileService _labProfileService;
    private readonly ILogger<LabProfileController> _logger;
    private readonly IUserManagementService _accountService;
    private readonly UserManager<ApplicationUser> _userManager;

    public LabProfileController(ILabProfileService labProfileService, ILogger<LabProfileController> logger, UserManager<ApplicationUser> userManager)
    {  _labProfileService = labProfileService;
        _logger = logger;
        _userManager = userManager;
    }
    
    [Route("viewlab")]
    public async Task<IActionResult> ViewLab(MultiModel model)
    {
        model.info = await _labProfileService.GetAllLabAccounts();
        return View("Index", model); 
    }
    
    // [Authorize(Roles="Admin")]
    /*Redirect to lab view*/
    [Route("labregister")]
    public async Task<IActionResult> LabRegister()
    {
        /*var labform = new LabRegisterViewModel() {LabICList = await _userManager.GetUsersInRoleAsync("labtech")};*/
        return View("LabRegister");
    }

    /*[Authorize(Roles="Admin")]*/
    [HttpPost]
    /*Create labs by admins*/
    public async Task<IActionResult> LabRegisterPost(LabRegisterViewModel labModel)
    {
        if (ModelState.IsValid)
        {
            await _labProfileService.NewLab(labModel);
            return View("_CompleteRegister");
        }
        return View(nameof(LabRegister));
        
    }
    
    [Route("view/{labLocation}")]
    public async Task<ViewResult> LabProfile(MultiModel combinedModels, string labLocation)
    {
        var labModel = await _labProfileService.GetLabProfileDetails(labLocation);
        var devicestype = await _labProfileService.ViewDeviceType(labLocation);
        var accessoriestype = await _labProfileService.ViewAccessoryType(labLocation);

        combinedModels.eachlab = new LabInformationModel()
        {
            LabLocation = labModel.LabLocation,
            LabInCharge = labModel.LabInCharge,
            Capacity = labModel.Capacity,
            Occupied = labModel.Occupied,
            deviceNames = devicestype,
            accessoriesNames = accessoriestype
        };
        
        _logger.LogInformation("Lab ID is" + labModel.LabId);
        _logger.LogInformation("Lab Devices " + devicestype);

        return View("LabProfile", combinedModels);
    }

    public async Task<IActionResult> GoToManageDevices()
    {
        _logger.LogInformation("Go To Manage Devices");
        return View("LabProfile");
    }
}
