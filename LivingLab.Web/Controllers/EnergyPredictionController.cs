using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;

public class EnergyPredictionController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
