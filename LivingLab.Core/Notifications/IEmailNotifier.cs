using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Notifications;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IEmailNotifier : INotifier
{
    Task SendEmailAsync(string email, string subject, string htmlMessage);

    Task<List<ApplicationUser>> GetEmail();
}
