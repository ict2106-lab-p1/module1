using LivingLab.Core.DomainServices.Notifications;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Enums;
using LivingLab.Core.Notifications;

namespace LivingLab.Web.UIServices.NotificationManagement;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class NotificationManagementService : INotificationManagementService
{
    private readonly INotificationDomainService _notificationDomainService;
    private readonly IEmailNotifier _emailNotifier;
    private readonly ISmsNotifier _smsNotifier;

    public NotificationManagementService(IEmailNotifier emailNotifier, ISmsNotifier smsNotifier, INotificationDomainService notificationDomainService)
    {
        _notificationDomainService = notificationDomainService;
        _emailNotifier = emailNotifier;
        _smsNotifier = smsNotifier;
    }

    /// <summary>
    /// Call Notification Domain Service to set the notification preference of the current user
    /// </summary>
    /// <param name="currentUser, preference"></param>
    public Task SetNotificationPref(ApplicationUser currentUser, NotificationType preference)
    {
        return _notificationDomainService.SetNotificationPref(currentUser, preference);
    }

    /// <summary>
    /// Call SMS Notifier to send SMS to phone number
    /// </summary>
    /// <param name="phone, msgBody"></param>
    public async Task SendTextToPhone(string phone, string msgBody)
    {
        await _smsNotifier.SendSmsAsync(phone, msgBody);

    }

    /// <summary>
    /// Call Email Notifier to send Email to email address
    /// </summary>
    /// <param name="email, title, message"></param>
    public async Task SendTextToEmail(string email, string title, string htmlMessage)
    {
        await _emailNotifier.SendEmailAsync(email, title, htmlMessage);
    }
}
