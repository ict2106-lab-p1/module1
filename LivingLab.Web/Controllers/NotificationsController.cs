using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;

public class NotificationsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
