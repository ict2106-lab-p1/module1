using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Controllers.Api;
using LivingLab.Web.UIServices.UserManagement;
using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.UIServices.Account;
using LivingLab.Web.UIServices.LabProfile;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Lab;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileController: Controller
{
    private readonly ILabProfileService _labProfileService;
    private readonly ILogger<LabProfileController> _logger;
    private readonly IUserManagementService _accountService;

    public LabProfileController(ILabProfileService labProfileService, ILogger<LabProfileController> logger)
    {  _labProfileService = labProfileService;
        _logger = logger;
    }
    
    [HttpGet]
    [Authorize(Roles = "Users,Admin,Labtech")]
    public async Task<IActionResult> ViewLab(MultiModel model)
    {
        model.info = await _labProfileService.GetAllLabAccounts();
        return View("Index", model); 
    }
    
    
    [Authorize(Roles="Admin")]
    /*Redirect to lab view*/
    [HttpGet]
    public async Task<IActionResult> LabRegister()
    {
        return View("LabRegister");
    }

    [HttpPost]
    [Authorize(Roles="Admin")]
    /*Create labs by admins*/
    [HttpPost]
    public async Task<IActionResult> LabRegister(LabRegisterViewModel labform)
    {
        if (ModelState.IsValid)
        {
            await _labProfileService.NewLab(labform);
            return View("_CompleteRegister");
        }
        return View("LabRegister");
    }
    
    [HttpGet]
    [Route("ViewLab/{labLocation}")]
    public async Task<ViewResult> LabProfile(string labLocation)
    {
        MultiModel combinedModels = new MultiModel();
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
