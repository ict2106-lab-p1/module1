using System.Diagnostics;

using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.EnergyUsage;
using LivingLab.Web.UIServices.LabProfile;
using LivingLab.Web.UIServices.ManualLogs;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
[Authorize(Roles = "Labtech")]
public class ManualLogsController : Controller
{
    private readonly IManualLogService _manualLogService;
    private readonly ILabProfileService _labProfileService;
    private readonly ILogger<ManualLogsController> _logger;

    public ManualLogsController(IManualLogService manualLogService, ILabProfileService labProfileService,
        ILogger<ManualLogsController> logger)
    {
        _manualLogService = manualLogService;
        _labProfileService = labProfileService;
        _logger = logger;
    }

    /// <summary>
    /// Route to Index
    /// </summary>
    /// <returns>Index View</returns>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Route to File Upload
    /// </summary>
    /// <returns>FileUpload View</returns>
    public IActionResult FileUpload()
    {
        return View();
    }

    /// <summary>
    /// Route to Manual Log Upload
    /// </summary>
    /// <returns>labs model</returns>
    public async Task<IActionResult> ManualLogUpload()
    {
        var labs = await _labProfileService.GetAllLabAccounts();
        return View(labs);
    }

    /// <summary>
    /// Route to Manual Log via File Upload
    /// </summary>
    /// <param name="file"></param>
    /// <returns>status 200</returns>
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

    /// <summary>
    /// Save the logs uploaded to the system
    /// </summary>
    /// <param name="logs"></param>
    /// <returns>status 200</returns>
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
