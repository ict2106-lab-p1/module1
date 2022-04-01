using System.Diagnostics;

using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.EnergyUsage;
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
    public async Task<IActionResult> Upload(IFormFile file)
    {
        try
        {
            var count = await _manualLogService.UploadLogs(file);
            return Ok(count);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] List<LogItemViewModel> logs)
    {
        try
        {
            if (logs.Count == 0) return Error();
            
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
