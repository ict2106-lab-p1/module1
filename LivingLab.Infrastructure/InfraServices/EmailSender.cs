using System.Net;
using System.Net.Mail;

using Microsoft.AspNetCore.Identity.UI.Services;

namespace LivingLab.Infrastructure.InfraServices;

/*Send email using Google mail Living.Lab*/
public class EmailSender : Core.Interfaces.Services.IEmailSender
{
    public EmailSender()
    {
 
    }
 
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        string fromMail = "LivingLab2022.NoReply@gmail.com";
        string fromPassword = "aejrbvdnrrwqkogs";
 
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
