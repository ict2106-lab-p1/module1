using LivingLab.Core.Enums;
using LivingLab.Core.Notifications;

namespace LivingLab.Core.DomainServices.Notifications;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class NotifierFactory
{
    private readonly ISmsNotifier _smsNotifier;
    private readonly IEmailNotifier _emailNotifier;

    public NotifierFactory(ISmsNotifier smsNotifier, IEmailNotifier emailNotifier)
    {
        _smsNotifier = smsNotifier;
        _emailNotifier = emailNotifier;
    }

    /// <summary>
    /// Creates a notifier based on the given notification type.
    /// </summary>
    /// <param name="preference">Notification preference</param>
    /// <returns>Notifier instance</returns>
    public INotifier CreateNotifier(NotificationType preference)
    {
        if (preference == NotificationType.SMS)
            return _smsNotifier;

        return _emailNotifier;
    }
}
