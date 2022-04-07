using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Enums;

namespace LivingLab.Web.UIServices.NotificationManagement;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface INotificationManagementService
{
    Task SetNotificationPref(ApplicationUser currentUser, NotificationType preference);

    Task SendTextToPhone(string phone, string msgBody);

    // By Henry
    Task SendTextToEmail(string email, string subject, string message);
}
