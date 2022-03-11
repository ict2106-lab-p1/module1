using System.Diagnostics;

using LivingLab.Web.Models.ViewModels;
<<<<<<< HEAD
=======

using Microsoft.AspNetCore.Authorization;
// using LivingLab.Web.ViewModels;
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9

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

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("/")]
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
<<<<<<< HEAD
    {
        //Delete the Session object.
        HttpContext.Session.Clear();
        return View("Index");
    }



    [Route("/example")]
    public IActionResult ExamplePage()
=======
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
    {
        //Delete the Session object.
        HttpContext.Session.Clear();
        return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
