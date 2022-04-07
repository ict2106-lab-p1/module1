using System.Net;
using System.Net.Mail;

using LivingLab.Core.DomainServices.Notifications;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Enums;
using LivingLab.Core.Notifications;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace LivingLab.Infrastructure.InfraServices.Notification;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EmailNotifier : IEmailNotifier
{
    private readonly INotificationDomainService _notificationDomainService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _config;

    public EmailNotifier(INotificationDomainService notificationDomainService, UserManager<ApplicationUser> userManager, IConfiguration config)
    {
        _notificationDomainService = notificationDomainService;
        _userManager = userManager;
        _config = config;
    }

    /// <summary>send email</summary>
    /// <param name="email">recipient email address</param>
    /// <param name="subject">subject/title of email</param>
    /// <param name="htmlMessage">content body of email, can be HTML formatted</param>
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var fromMail = _config["LivingLab:DEFAULT_SYSTEM_EMAILADDRESS"];
        var fromPassword = _config["LivingLab:DEFAULT_SYSTEM_PASSWORD"];

        var message = new MailMessage();
        message.From = new MailAddress(fromMail);
        message.Subject = subject;
        message.To.Add(new MailAddress(email));
        message.Body = "<html><body> " + htmlMessage + " </body></html>";
        message.IsBodyHtml = true;

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromMail, fromPassword),
            EnableSsl = true,
        };
        smtpClient.Send(message);
        return Task.CompletedTask;
    }

    /// <summary>send notification via email</summary>
    /// <param name="message">email message text</param>
    [Obsolete]
    public async Task Notify(string message)
    {
        foreach (var labTechnicianDetails in GetEmail().Result)
        {
            string subject = "Device(s) exceeded Threshold Limit";

            // email message body
            string msgBody = "Hi " + labTechnicianDetails.FirstName + labTechnicianDetails.LastName +
                             ", " + message;
            await SendEmailAsync(labTechnicianDetails.Email, subject, msgBody);
        }
    }

    /// <summary>
    /// Retrieve list of Lab Technicians whose Notification Preference is Email
    /// </summary>
    /// <returns>list of lab technicians</returns>
    [Obsolete]
    public async Task<List<ApplicationUser>> GetEmail()
    {
        var labTechnicians = await
            _notificationDomainService.GetAllTechniciansWithNotiPref(NotificationType.EMAIL);
        return labTechnicians;
    }
}
