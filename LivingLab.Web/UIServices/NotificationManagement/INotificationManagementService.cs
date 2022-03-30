using LivingLab.Core.Entities.Identity;

namespace LivingLab.Web.UIServices.NotificationManagement;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface INotificationManagementService
{
    Task SetNotificationPref();

    Task SendTextToPhone(string phone, string msgBody);

    Task SendTextToEmail(string email, string msgTitle, string msgBody);

}
