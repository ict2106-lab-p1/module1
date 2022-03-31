using LivingLab.Web.Controllers.Api;
using LivingLab.Web.UIServices.LivingLabDashboard;
using LivingLab.Web.UIServices.UserManagement;
using LivingLab.Web.Models.ViewModels.LivingLabDashboard;
using LivingLab.Web.UIServices.LivingLabDashboard;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LivingLabDashboardController: Controller
{
    private readonly ILogger<LivingLabDashboardController> _logger;
    private readonly IUserManagementService _accountService;
    private readonly ILivingLabDashboardService _dashboardService;
    public LivingLabDashboardController(ILogger<LivingLabDashboardController> logger, IUserManagementService accountService, ILivingLabDashboardService dashboardService)
    {
        _logger = logger;
        _accountService = accountService;
        _dashboardService = dashboardService;
    }
    public async Task<IActionResult> Dashboard()
    {
        Console.WriteLine("testing");
        LivingLabDashboardViewModel viewLabs = await _dashboardService.GetAllLabs();
        return View("Dashboard", viewLabs);
    }

}
