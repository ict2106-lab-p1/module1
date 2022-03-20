using LivingLab.Core.Entities.DTO;
using LivingLab.Web.Models.ViewModels.SessionStats;
using LivingLab.Web.UIServices.SessionStats;

namespace LivingLab.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
/// <remarks>
/// Author: Team P1-3
/// </remarks>

[Route("SessionStats")]
public class SessionStatsController : Controller
{
    private readonly ILogger<SessionStatsController> _logger;
    private readonly ISessionStatsService _sessionStatsService;
    
    public SessionStatsController(ILogger<SessionStatsController> logger, ISessionStatsService sessionStatsService)
    {
        _logger = logger;
        _sessionStatsService = sessionStatsService;
    }
    
    public async Task<IActionResult> ViewSessionStats()
    {
        ViewSessionStatsViewModel viewSessionStats = await _sessionStatsService.ViewSessionStats();
        return View("ViewSessionStats", viewSessionStats);
    }
}
