using LivingLab.Web.Models.DTOs;
using LivingLab.Web.UIServices.EnergyLog;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Api;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
[Route("api/energylog/[action]")]
public class EnergyLogApiController : BaseApiController
{
    private readonly IEnergyLogService _energyLogService;
    private readonly ILogger<EnergyLogApiController> _logger;
    public EnergyLogApiController(IEnergyLogService energyLogService, ILogger<EnergyLogApiController> logger)
    {
        _energyLogService = energyLogService;
        _logger = logger;
    }

    /// <summary>
    /// Get the number of energy usage logs
    /// </summary>
    /// <param name="size"></param>
    /// <returns>Json(logs)</returns>
    [HttpGet("{size}")]
    public async Task<IActionResult> GetLogs(int size)
    {
        try
        {
            var logs = await _energyLogService.GetLogs(size);
            return Json(logs);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Log energy usage into the system
    /// </summary>
    /// <param name="usage"></param>
    /// <returns>status 200</returns>
    [HttpPost]
    public async Task<IActionResult> Log(EnergyUsageLogDTO usage)
    {
        try
        {
            await _energyLogService.Log(usage);
            return Ok($"Successfully logged energy usage for {usage.DeviceSerialNo}");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e.Message);
        }
    }
}
