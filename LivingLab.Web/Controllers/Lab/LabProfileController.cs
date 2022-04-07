using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.UIServices.LabProfile;
using LivingLab.Web.UIServices.UserManagement;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Lab;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileController : Controller
{
    private readonly ILabProfileService _labProfileService;
    private readonly ILogger<LabProfileController> _logger;
    private readonly IUserManagementService _accountService;


    public LabProfileController(ILabProfileService labProfileService, ILogger<LabProfileController> logger)
    {
        _labProfileService = labProfileService;
        _logger = logger;
    }

    /// <summary>
    /// List of lab profiles can only be seen by Admins and Lab Technicians
    /// Display the list of labs information in the lab profile Index page
    /// </summary>
    /// <returns>A list of lab information in the lab profile Index page </returns>
    [HttpGet]
    [Authorize(Roles = "Users,Admin,Labtech")]
    public async Task<IActionResult> ViewLab(MultiModel model)
    {
        model.info = await _labProfileService.GetAllLabAccounts();
        return View("Index", model);
    }

    /// <summary>
    /// Reroute to lab register view
    /// </summary>
    /// <returns>Lab Register Page</returns>
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public IActionResult LabRegister()
    {
        return View("LabRegister");
    }

    /// <summary>
    /// 1. Check if viewModel is filled
    /// </summary>
    /// <param name="labform">Parse labRegisterViewModel form</param>
    /// <returns>Complete Register Page if successful</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
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

    /// <summary>
    /// Display the Individual Lab Profile details as such the basic lab profile details,
    /// lab devices available and lab accessory available
    /// </summary>
    /// <returns> Lab Profile details in each lab based on lab location</returns>

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
            LabId = labModel.LabId,
            LabLocation = labModel.LabLocation,
            LabInCharge = labModel.LabInCharge,
            Capacity = labModel.Capacity,
            Occupied = labModel.Occupied,
            deviceNames = devicestype,
            accessoriesNames = accessoriestype
        };

        return View("LabProfile", combinedModels);
    }

}
