using System.Diagnostics;

using LivingLab.Web.Models.ViewModels;
// using LivingLab.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;

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
        return View("Index");
    }

    [Route("privacy")]
    public IActionResult Privacy()
    {
        return View("Privacy");
    }
    
    [Route("booking")]
    public IActionResult Booking()
    {
        return View("Appointment");
    }
    
    [Route("manageUsers")]
    public IActionResult ManageUsers()
    {
        return View("ManageUsers");
    }
    
    [Route("manageLabBookings")]
    public IActionResult ManageLabBookings()
    {
        return View("ManageLabBooking");
    }

    
    [Route("manageLabUsers")]
    public IActionResult ManageLabUsers()
    {
        return View("ManageLabUsers");
    }

    [Route("createLabAccount")]
    public IActionResult CreateLabAccount()
    {
        return View("CreateLabAccount");
    }

    [Route("createLabTechAccount")]
    public IActionResult CreateLabTechAccount()
    {
        return View("CreateLabTechAccount");
    }
    
    

    [Route("labProfile")]
    public IActionResult LabProfile()
    {
        return View("LabProfile");
    }
    
    [Route("SMSAuth")]
    public IActionResult SMSAuth()
    {
        return View("SMSAuth");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
