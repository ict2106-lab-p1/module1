using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyPredictionController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
