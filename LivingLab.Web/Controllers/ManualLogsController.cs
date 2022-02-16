using System.Diagnostics;

using LivingLab.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;

//[Route("ManualLogs")]
public class ManualLogsController : Controller
{
    private readonly ILogger<ManualLogsController> _logger;

    public ManualLogsController(ILogger<ManualLogsController> logger)
    {
        _logger = logger;
    }

    //[Route("ManualLogs/")]
    public IActionResult Index()
    {
        return View("Index");
    }
    
    public IActionResult FileUpload()
    {
        return View("FileUpload");
    }
    
    public IActionResult ManualLogUpload()
    {
        return View("ManualLogUpload");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
