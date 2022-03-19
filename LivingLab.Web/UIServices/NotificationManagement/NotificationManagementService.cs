using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Services;

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

    
    public NotificationManagementService(INotificationDomainService notificationDomainService, ILogger<NotificationManagementService> logger)
    {
        _notificationDomainService = notificationDomainService;
        _logger = logger;
    }
    
    public Task SetNotificationPref()
    {
        return _notificationDomainService.SetNotificationPref();
    }

    public async Task SendTextToPhone(ApplicationUser user)
    {
        // Find your Account SID and Auth Token at twilio.com/console
        // and set the environment variables. See http://twil.io/secure
        string accountSid = "AC7ef3169ab7a740f0ebb42a0643a5be7b";
        string authToken = "ad1b1652b2d931d7750455a847e0ab89";

        TwilioClient.Init(accountSid, authToken);
        
        string msgbody = "Your 6 digit OTP for Living Lab is " + user.OTP;

        var messageOptions = new CreateMessageOptions(new PhoneNumber("+6596876870"));   
        messageOptions.MessagingServiceSid = "MG7d7cd6b53ca04365964a61a99448d3e0";  
        messageOptions.Body = msgbody;   
 
        var message = MessageResource.Create(messageOptions); 
        Console.WriteLine(message.Body); 
    
    }
}
