using System.Net;
using System.Net.Mail;

using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LivingLab.Infrastructure.InfraServices;

/*Send email using Google mail Living.Lab*/
public class EmailSender : Core.Interfaces.Services.IEmailSender
{
    private readonly ILogger<EmailSender> _logger;
    private readonly IConfiguration _config;
    public EmailSender(IConfiguration config, ILogger<EmailSender> logger)
    {
        _config = config;
        _logger = logger;
    }
    
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        string? fromMail = _config.GetSection("LivingLab:DEFAULT_SYSTEM_EMAILADDRESS").Value;
        string? fromPassword = _config.GetSection("LivingLab:DEFAULT_SYSTEM_PASSWORD").Value;
 
        MailMessage message = new MailMessage();
        message.From = new MailAddress(fromMail);
        message.Subject = subject;
        message.To.Add(new MailAddress(email));
        message.Body ="<html><body> " + htmlMessage + " </body></html>";
        message.IsBodyHtml = true;
 
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromMail, fromPassword),
            EnableSsl = true,
        };
        smtpClient.Send(message);
    }
 
}
