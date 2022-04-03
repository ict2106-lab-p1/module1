using LivingLab.Core.Enums;
using LivingLab.Core.Notifications;

namespace LivingLab.Core.DomainServices.Notifications;

public class NotifierFactory
{
    private readonly ISmsNotifier _smsNotifier;
    private readonly IEmailNotifier _emailNotifier;
    
    public NotifierFactory(ISmsNotifier smsNotifier, IEmailNotifier emailNotifier)
    {
        _smsNotifier = smsNotifier;
        _emailNotifier = emailNotifier;
    }
    public INotifier CreateNotifier(NotificationType preference)
    {
        if (preference == NotificationType.SMS)
        {
            return _smsNotifier;
        }
        else
        {
            return _emailNotifier;
        }
    }
}
