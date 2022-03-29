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
    
    [HttpPost]
    public async Task<IActionResult> Log(EnergyUsageLogDTO usage)
    {
        try
        {
            await _energyLogService.Log(usage);
            return Ok("Successfully logged energy usage");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e.Message);
        }
    }
}
