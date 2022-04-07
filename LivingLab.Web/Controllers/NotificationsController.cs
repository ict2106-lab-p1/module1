using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels;
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

    /// <summary>
    /// Get the user's preferred notification channel (email or sms)
    /// </summary>
    /// <returns>Redirect to Notification index</returns>
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        NotificationPrefViewModel notiPrefViewModel = new NotificationPrefViewModel
        {
            PreferredNotification = user.PreferredNotification
        };
        return View("Index", notiPrefViewModel);
    }

    /// <summary>
    /// Update the user's notification preference upon selecting a notification mode in the dropdown
    /// </summary>
    /// <param name="notiPrefViewModel"></param>
    /// <returns>Redirect to Notification index</returns>
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> UpdateNotificationPreference(NotificationPrefViewModel notiPrefViewModel)
    {
        var user = await _userManager.GetUserAsync(User);
        await _notificationManager.SetNotificationPref(user, notiPrefViewModel.PreferredNotification);
        return View("Index", notiPrefViewModel);
    }
}
