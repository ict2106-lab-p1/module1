using System.Diagnostics;

using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.Models.ViewModels.UserManagement;
using LivingLab.Web.UIServices.LabProfile;
using LivingLab.Web.UIServices.UserManagement;
using LivingLab.Web.Models.ViewModels.Login;
using LivingLab.Web.UIServices.Account;
using LivingLab.Web.UIServices.NotificationManagement;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ILabProfileService _labProfileService;
    private readonly SignInManager<ApplicationUser> _signInManager;


    public HomeController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager,  ILabProfileService labProfileService)
    {
        _logger = logger;
        _signInManager = signInManager;
        _labProfileService = labProfileService;
    }

    /*Reroute the users to the login page*/
    [AllowAnonymous]
    [Route("/")]
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Login");
    }

    /*Reroute the users to the main dashboard*/
    [Authorize(Roles = "User,Labtech,Admin")]
    [Route ("dashboard")]
    public IActionResult Dashboard()
    {
        //TODO: RedirectToLivingLab, for now its directing to lab profile
        return RedirectToAction("ViewLab", "LabProfile");
    }

    /*Privacy page which was built in*/
    [Authorize(Roles = "Admin")]
    [Route("privacy")]
    public IActionResult Privacy()
    {
        return View("Privacy");
    }
    
    /*Can be called to remove the user*/
    [Authorize(Roles = "User,Labtech,Admin")]
    [Route("logout")]
    public IActionResult Logout()
    {
        _logger.LogInformation("Logging out");
        //Delete the Session object.
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        _signInManager.SignOutAsync();
        HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
        return RedirectToAction("Index", "Login");
    }

    /*Not in use, just an example*/
    [Route("/example")]
    public IActionResult ExamplePage()
    {
        return View("ExamplePage");
    }

    // [Route("/Index")]
    // public async Task<IActionResult> Labs()
    // {
    //     ViewLabProfileViewModel viewLabProfileViewModel = await _labProfileService.GetAllLabAccounts();
    //     Console.WriteLine("test");
    //     return View("Index", viewLabProfileViewModel); 
    // }

}
