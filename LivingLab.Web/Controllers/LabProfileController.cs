using LivingLab.Web.Controllers.Api;
using LivingLab.Web.UIServices.UserManagement;
using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.UIServices.Account;
using LivingLab.Web.UIServices.LabProfile;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;
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
    
    [Route("viewlab")]
    public async Task<IActionResult> ViewLab()
    {
        ViewLabProfileViewModel viewLabProfileViewModel = await _labProfileService.GetAllLabAccounts();
        return View("Index", viewLabProfileViewModel); 
    }
    
    [Authorize(Roles="Admin")]
    /*Redirect to lab view*/
    [Route("labregister")]
    public IActionResult LabRegister()
    {
        return View("LabRegister");
    }

    [Authorize(Roles="Admin")]
    [HttpPost]
    /*Create labs by admins*/
    public async Task<IActionResult> LabRegister(LabProfileViewModel labModel)
    {
        if (ModelState.IsValid)
        {
            await _labProfileService.NewLab(labModel);
            _logger.LogInformation("Test Successful");
            return View("LabRegister", labModel);
        }
        
        _logger.LogInformation("Test fail");
        return View(nameof(LabRegister));
        
    }
}
