using LivingLab.Core.DomainServices.Notifications;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Enums;
using LivingLab.Core.Notifications;

using Microsoft.AspNetCore.Identity.UI.Services;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace LivingLab.Web.UIServices.NotificationManagement;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class NotificationManagementService : INotificationManagementService
{
    private readonly INotificationDomainService _notificationDomainService;
    private readonly ILogger<NotificationManagementService> _logger;
    private readonly IEmailNotifier _emailNotifier;
    private readonly ISmsNotifier _smsNotifier;
    private readonly IConfiguration _config;
    
    public NotificationManagementService(IEmailNotifier emailNotifier, ISmsNotifier smsNotifier,IConfiguration config, INotificationDomainService notificationDomainService, ILogger<NotificationManagementService> logger)
    {
        _notificationDomainService = notificationDomainService;
        _logger = logger;
        _config = config;
        _emailNotifier = emailNotifier;
        _smsNotifier = smsNotifier;
    }
    
    public Task SetNotificationPref(ApplicationUser currentUser, NotificationType preference)
    {
        return _notificationDomainService.SetNotificationPref(currentUser, preference);
    }

    public async Task SendTextToPhone(string phone, string msgBody)
    {
        await _smsNotifier.SendSmsAsync(phone, msgBody);
        
    }
    
    /*Send Email to an address, details are defined in the domain services*/
    public async Task SendTextToEmail(string email, string title, string message)
    {
        await _emailNotifier.SendEmailAsync(email, title, htmlMessage: message);
    }
}
