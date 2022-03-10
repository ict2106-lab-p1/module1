using System.Diagnostics;

using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.UIServices.ManualLogs;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class ManualLogsController : Controller
{
    private readonly IManualLogService _manualLogService;
    private readonly ILogger<ManualLogsController> _logger;

    public ManualLogsController(IManualLogService manualLogService, ILogger<ManualLogsController> logger)
    {
        _manualLogService = manualLogService;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult FileUpload()
    {
        return View();
    }

    public IActionResult ManualLogUpload()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Upload(IFormFile file)
    {
        try
        {
            var viewModel = _manualLogService.UploadLogs(file);
            return View(nameof(FileUpload), viewModel);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return View(nameof(FileUpload));
        }
    }

    [HttpPost]
    public async Task<IActionResult> Save(List<LogItemViewModel> logs)
    {
        try
        {
            await _manualLogService.SaveLogs(logs);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return Error();
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
