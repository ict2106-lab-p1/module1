using System.Diagnostics;

using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.Models.ViewModels.UserManagement;
using LivingLab.Web.UIServices.LabProfile;
using LivingLab.Web.UIServices.UserManagement;
using LivingLab.Web.Models.ViewModels.Login;
using LivingLab.Web.UIServices.Account;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

    [Route("/")]
    public async Task<IActionResult> Index()
    {
        // HttpContext.Session.SetInt32("UserID", 1);
        // return View("Index");
        ViewLabProfileViewModel viewLabProfileViewModel = await _labProfileService.GetAllLabAccounts();
        Console.WriteLine("test");
        return View("Index", viewLabProfileViewModel); 
        
    }
    // public IActionResult Index()
    // {
    //     return View("Index");
    // }

    [Route("privacy")]
    public IActionResult Privacy()
    {
        return View("Privacy");
    }
    [Route("Logout")]
    public IActionResult Logout()
    {
        //Delete the Session object.
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        _signInManager.SignOutAsync();
        HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
        return RedirectToAction("Index");
    }


    //
    // [Route("/example")]
    // public IActionResult ExamplePage()
    // {
    //     return View("ExamplePage");
    // }
    //
    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
    
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
    [Route("View/{id}")]
    public async Task<LabProfileViewModel> ViewLabDetails(int id)
    { 
        //retrieve data from db
        LabProfileViewModel lab = await _labProfileService.ViewLabDetails(id);
        return lab;
    }

}
