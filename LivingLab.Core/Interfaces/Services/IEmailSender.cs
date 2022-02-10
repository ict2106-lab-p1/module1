namespace LivingLab.Domain.Interfaces.Services;

public interface IEmailSender
{
    Task SendEmailAsync(string to, string from, string subject, string body);
}
