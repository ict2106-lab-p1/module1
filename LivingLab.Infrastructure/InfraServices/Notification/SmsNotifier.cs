using LivingLab.Core.DomainServices.Notifications;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Enums;
using LivingLab.Core.Notifications;

using Microsoft.Extensions.Configuration;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace LivingLab.Infrastructure.InfraServices.Notification;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class SmsNotifier : ISmsNotifier
{
    private readonly INotificationDomainService _notificationDomainService;
    private readonly IConfiguration _config;

    public SmsNotifier(INotificationDomainService notificationDomainService, IConfiguration config)
    {
        _notificationDomainService = notificationDomainService;
        _config = config;
    }
    
    /// <summary>send sms</summary>
    /// <param name="phone">recipient phone number</param>
    /// <param name="msgBody">content body of SMS, strictly plaintext only</param>
    public Task SendSmsAsync(string phone, string msgBody)
    {
        // Find your Account SID and Auth Token at twilio.com/console
        // and set the environment variables. See http://twil.io/secure
        // string accountSid = _config.GetSection("LivingLab:TWILIO_ACC_ID").Value;
        // string authToken = _config.GetSection("LivingLab:TWILIO_AUTH_ID").Value;
        var accountSid = _config["LivingLab:TWILIO_ACC_ID"];
        var authToken = _config["LivingLab:TWILIO_AUTH_ID"];

        TwilioClient.Init(accountSid, authToken);

        var messageOptions = new CreateMessageOptions(new PhoneNumber(phone));
        // messageOptions.MessagingServiceSid = _config.GetSection("LivingLab:TWILIO_MSG_SERVICE_ID").Value;  
        messageOptions.MessagingServiceSid = _config["LivingLab:TWILIO_MSG_SERVICE_ID"];
        messageOptions.Body = msgBody;

        var message = MessageResource.Create(messageOptions);
        Console.WriteLine(message.Body);
        return Task.CompletedTask;
    }

    /// <summary>send notification via sms</summary>
    /// <param name="message">notification message text</param>
    [Obsolete]
    public async Task Notify(string message)
    {
        foreach (var labTechnicianDetails in GetPhoneNumber().Result)
        {
            //message - contains device id & exceeded threshold amt
            string msgBody = "Hi " + labTechnicianDetails.FirstName + labTechnicianDetails.LastName
                             + ", " + message;
            await SendSmsAsync("+65" + labTechnicianDetails.PhoneNumber, msgBody);
        }
    }

    /// <summary>
    /// Retrieve list of Lab Technicians whose Notification Preference is SMS
    /// </summary>
    /// <returns>list of lab technicians</returns>
    [Obsolete]
    public async Task<List<ApplicationUser>> GetPhoneNumber()
    {
        var labTechnicians = await
            _notificationDomainService.GetAllTechniciansWithNotiPref(NotificationType.SMS);
        return labTechnicians;
    }
}
