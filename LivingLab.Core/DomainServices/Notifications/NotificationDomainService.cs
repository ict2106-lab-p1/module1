using LivingLab.Core.DomainServices.Account;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Enums;
using LivingLab.Core.Repositories.Notification;

using Microsoft.Extensions.Logging;

namespace LivingLab.Core.DomainServices.Notifications;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class NotificationDomainService : INotificationDomainService
{
    private readonly IEmailRepository _emailRepository;
    private readonly ISmsRepository _smsRepository;
    private readonly IAccountDomainService _accountDomainService;
    private readonly ILogger<NotificationDomainService> _logger;
    
    public NotificationDomainService(IAccountDomainService accountDomainService, ILogger<NotificationDomainService> logger, IEmailRepository emailRepository, ISmsRepository smsRepository)
    {
        _accountDomainService = accountDomainService;
        _logger = logger;
        _emailRepository = emailRepository;
        _smsRepository = smsRepository;
    }
    public Task SetNotificationPref(ApplicationUser currentUser, NotificationType preference)
    {
        currentUser.PreferredNotification = preference;
        return _accountDomainService.UpdateUser(currentUser);
    }

    /*
     * Get list of technicians who chose Email as their preferred notification style
     */
    public Task<List<ApplicationUser>> GetAllTechniciansWithNotiPref(NotificationType preference)
    {
        return _emailRepository.GetAccountByNotiPref(preference);
    }

    /*public Task<List<ApplicationUser>> GetAllTechniciansWithNotiPref(NotificationType preference)
    {
        return _smsRepository.GetAccountByNotiPref(preference);
    }*/
}
