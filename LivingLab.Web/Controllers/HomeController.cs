using System.Diagnostics;

using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.Models.ViewModels.UserManagement;
using LivingLab.Web.UIServices.LabProfile;
using LivingLab.Web.UIServices.UserManagement;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
[Route("home")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ILabProfileService _labProfileService;
    
    public HomeController(ILogger<HomeController> logger, ILabProfileService labProfileService)
    {
        _logger = logger;
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

    [Route("privacy")]
    public IActionResult Privacy()
    {
        return View("Privacy");
    }
    
    // [HttpPost]
    // public IActionResult SetSession()
    // {
    //     //Set value in Session object.
    //     HttpContext.Session.SetString("Name", "Mudassar Khan");
    //
    //     return RedirectToAction("Index");
    // }
    // [HttpPost]
    // public IActionResult DeleteSession()
    // {
    //     //Delete the Session object.
    //     HttpContext.Session.Remove("UserID");
    //     
    //     return RedirectToAction("Index");
    //     
    // }
    [Route("Logout")]
    public IActionResult Logout()
    {
        //Delete the Session object.
        HttpContext.Session.Clear();
        return View("Index");
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
