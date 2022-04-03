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
    // public void Notify(string message)
    // {
    //     throw new NotImplementedException();
    // }
    public async Task SendSmsAsync(string phone, string msgBody)
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
    
    public async Task Notify(string message)
    {
        foreach (var labTechnicianDetails in GetPhoneNumber().Result)
        {
            //message - contains device id & exceeded threshold amt
            string msgBody = "Hi " + labTechnicianDetails.FirstName + labTechnicianDetails.LastName
                             + ", " + message;
            await SendSmsAsync("+65"+labTechnicianDetails.PhoneNumber, msgBody);
        }
        
        
    }

    /*
     * retrieves list of lab technicians whose notification pref is sms
     */
    public async Task<List<ApplicationUser>> GetPhoneNumber()
    {
        var labTechnicians = await
            _notificationDomainService.GetAllTechniciansWithNotiPref(NotificationType.SMS);
        return labTechnicians;
    }
}
