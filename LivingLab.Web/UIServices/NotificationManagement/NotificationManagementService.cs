using LivingLab.Core.Interfaces.Services;

namespace LivingLab.Web.UIServices.NotificationManagement;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class NotificationManagementService : INotificationManagementService
{
    private readonly INotificationDomainService _notificationDomainService;
    
    public NotificationManagementService(INotificationDomainService notificationDomainService)
    {
        _notificationDomainService = notificationDomainService;
    }
    
    public Task SetNotificationPref()
    {
        return _notificationDomainService.SetNotificationPref();
    }
}
