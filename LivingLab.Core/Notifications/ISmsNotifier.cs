using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Notifications;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface ISmsNotifier : INotifier
{
    Task SendSmsAsync(string phone, string msgBody);
    Task<List<ApplicationUser>> GetPhoneNumber();
}
