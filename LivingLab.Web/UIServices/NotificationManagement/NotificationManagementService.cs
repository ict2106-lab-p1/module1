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
        string accountSid = _config["TWILIO_ACC_ID"];
        string authToken = _config["TWILIO_AUTH_ID"];

        TwilioClient.Init(accountSid, authToken);

        var messageOptions = new CreateMessageOptions(new PhoneNumber(phone));   
        messageOptions.MessagingServiceSid = "MG7d7cd6b53ca04365964a61a99448d3e0";  
        messageOptions.Body = msgBody;   
 
        var message = MessageResource.Create(messageOptions); 
        Console.WriteLine(message.Body);
    }

    /*Send Email to an address, details are defined in the domain services*/
    public async Task SendTextToEmail(string email, string msgTitle, string msgBody)
    {
        await _emailSender.SendEmailAsync(email, msgTitle, msgBody);
    }
}
