using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.UIServices.Account;
using LivingLab.Web.UIServices.NotificationManagement;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class NotificationsController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly INotificationManagementService _notificationManager;

    public NotificationsController(UserManager<ApplicationUser> userManager, INotificationManagementService notificationManager)
    {
        _userManager = userManager;
        _notificationManager = notificationManager;
    }
    // GET
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        NotificationPrefViewModel notiPrefViewModel = new NotificationPrefViewModel {
            PreferredNotification = user.PreferredNotification
        };
        return View("Index", notiPrefViewModel);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> UpdateNotificationPreference(NotificationPrefViewModel notiPrefViewModel)
    {
        var user = await _userManager.GetUserAsync(User);
        await _notificationManager.SetNotificationPref(user, notiPrefViewModel.PreferredNotification);
        return View("Index", notiPrefViewModel);
    }
}
