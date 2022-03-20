using LivingLab.Web.Models.ViewModels.EnergyUsage;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ViewUsage(EnergyUsageViewModel usage)
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Filter(EnergyUsageFilterViewModel filter)
    {
        return Ok();
    }
    
    [HttpPost]
    public IActionResult SetBenchmark()
    {
        return Ok();
    }
}
