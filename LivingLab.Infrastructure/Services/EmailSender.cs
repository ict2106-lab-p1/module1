using LivingLab.Core.Interfaces.Services;

namespace LivingLab.Infrastructure.Services;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string to, string @from, string subject, string body)
    {
        throw new NotImplementedException();
    }
}
