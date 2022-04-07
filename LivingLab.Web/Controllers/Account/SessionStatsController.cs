using LivingLab.Web.Models.ViewModels.SessionStats;
using LivingLab.Web.UIServices.SessionStats;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Account;

/// <remarks>
/// Author: Team P1-3
/// </remarks>
[Authorize(Roles = "Labtech")]
[Route("SessionStats/{labLocation}")]
public class SessionStatsController : Controller
{
    private readonly ILogger<SessionStatsController> _logger;
    private readonly ISessionStatsService _sessionStatsService;

    public SessionStatsController(ILogger<SessionStatsController> logger, ISessionStatsService sessionStatsService)
    {
        _logger = logger;
        _sessionStatsService = sessionStatsService;
    }

    /// <summary>
    /// 1. Call Session Stats service to get all Session Stats according to the labLocation eg. NYP-SR7A
    /// </summary>
    /// <param name="labLocation">lab's location</param>
    /// <returns>ViewSessionStatsViewModel</returns>
    public async Task<IActionResult> ViewSessionStats(string labLocation)
    {
        ViewSessionStatsViewModel viewSessionStats = await _sessionStatsService.ViewSessionStats(labLocation);
        return View("ViewSessionStats", viewSessionStats);
    }

}
