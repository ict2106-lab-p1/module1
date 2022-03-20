using System.Diagnostics;

using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels;
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
    private readonly SignInManager<ApplicationUser> _signInManager;

    public HomeController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager)
    {
        _logger = logger;
        _signInManager = signInManager;

    }

    public IActionResult Index()
    {
        return View("Index");
    }

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

    [Route("/example")]
    public IActionResult ExamplePage()
    {
        return View("ExamplePage");
    }
    
 

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
