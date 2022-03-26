using LivingLab.Web.Models.ViewModels.UserManagement;
using LivingLab.Web.UIServices.UserManagement;

using Microsoft.AspNetCore.Authorization;

namespace LivingLab.Web.Controllers;

using System.Diagnostics;

using LivingLab.Web.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
[Route("p1_5/")]
public class P1_5Controller : Controller
{
    private readonly ILogger<P1_5Controller> _logger;
    private readonly IUserManagementService _userManagementService;

    
    
    public P1_5Controller(ILogger<P1_5Controller> logger, IUserManagementService userManagementService)
    {
        _logger = logger;
        _userManagementService = userManagementService;

    }
 
    [Route("booking")]
    public IActionResult Booking()
    {
        return View("Appointment");
    }
    
    // [Authorize]
    // [Route("manageUsers")]
    // public IActionResult ManageUsers()
    // {
    //     return View("ManageUsers");
    // }
    [Route("manageLabUsers")]
    
    public async Task<IActionResult> ManageLabUsers()
    {
        ViewUserManagementViewModel viewUserManagementViewModel = await _userManagementService.GetAllAccounts();
        return View("ManageLabUsers", viewUserManagementViewModel);
    } 
    //
    // [Route("manageLabBookings")]
    // public IActionResult ManageLabBookings()
    // {
    //     return View("ManageLabBooking");
    // }
    //
    //
    // [Route("manageLabUsers")]
    // public IActionResult ManageLabUsers()
    // {
    //     return View("ManageLabUsers");
    // }
    //
    //
    // [Route("createLabAccount")]
    // public IActionResult CreateLabAccount()
    // {
    //     return View("CreateLabAccount");
    // }
    //
    // [Route("createLabTechAccount")]
    // public IActionResult CreateLabTechAccount()
    // {
    //     return View("CreateLabTechAccount");
    // }
    //
    //
    //
    // [Route("labProfile")]
    // public IActionResult LabProfile()
    // {
    //     return View("LabProfile");
    // }
    //
    // [Route("SMSAuth")]
    // public IActionResult SMSAuth()
    // {
    //     return View("SMSAuth");
    // }
    //
    // [Route("VerifyCode")]
    // public IActionResult VerifyCode()
    // {
    //     return View("VerifyCode");
    // }
    //
    //
    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
    

    [Route("labProfile")]
    public IActionResult LabProfile()
    {
        return View("LabProfile");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

