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
    private readonly IConfiguration _config;
    private readonly IEmailSender _emailSender;

    
    public NotificationManagementService(IEmailSender emailSender, IConfiguration config, INotificationDomainService notificationDomainService, ILogger<NotificationManagementService> logger)
    {
        _notificationDomainService = notificationDomainService;
        _logger = logger;
        _config = config;
        _emailSender = emailSender;
    }
    
    public Task SetNotificationPref()
    {
        return _notificationDomainService.SetNotificationPref();
    }

    /*Send a normal SMS to the user*/
    public async Task SendTextToPhone(string phone, string msgBody)
    {
        // Find your Account SID and Auth Token at twilio.com/console
        // and set the environment variables. See http://twil.io/secure
        string? accountSid = _config.GetSection("LivingLab:TWILIO_ACC_ID").Value;
        string? authToken = _config.GetSection("LivingLab:TWILIO_AUTH_ID").Value;

        TwilioClient.Init(accountSid, authToken);

        var messageOptions = new CreateMessageOptions(new PhoneNumber(phone));   
        messageOptions.MessagingServiceSid = _config.GetSection("LivingLab:TWILIO_MSG_SERVICE_ID").Value;;  
        messageOptions.Body = msgBody;   
 
        var message = MessageResource.Create(messageOptions);
    }

    /*Send Email to an address, details are defined in the domain services*/
    public async Task SendTextToEmail(string email, string msgTitle, string msgBody)
    {
        await _emailSender.SendEmailAsync(email, msgTitle, msgBody);
    }
}
