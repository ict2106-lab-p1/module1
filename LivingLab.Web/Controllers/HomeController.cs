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
[Route("/")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SignInManager<ApplicationUser> _signInManager;
    // private readonly IAccountService _accountService;

    public HomeController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager)
    {
        _logger = logger;
        _signInManager = signInManager;
        // _accountService = accountService;

    }

    [Authorize]
    [Route("/home")]
    public IActionResult Index()
    {
        HttpContext.Session.SetInt32("UserID", 1);
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
    
    // [HttpPost]
    // public async Task<IActionResult> Save(string userid, RegisterViewModel registration)
    // {
    //     try
    //     {
    //         await _accountService.UpdateUser(userid, registration);
    //         return Ok();
    //     }
    //     catch (Exception e)
    //     {
    //         _logger.LogError(e.Message);
    //         return Error();
    //     }
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
