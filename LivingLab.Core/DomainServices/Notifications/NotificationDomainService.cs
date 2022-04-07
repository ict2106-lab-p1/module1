using LivingLab.Core.DomainServices.Account;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Enums;
using LivingLab.Core.Repositories.Notification;

namespace LivingLab.Core.DomainServices.Notifications;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class NotificationDomainService : INotificationDomainService
{
    private readonly IEmailRepository _emailRepository;
    private readonly IAccountDomainService _accountDomainService;

    public NotificationDomainService(IAccountDomainService accountDomainService, IEmailRepository emailRepository)
    {
        _accountDomainService = accountDomainService;
        _emailRepository = emailRepository;
    }

    /// <summary>
    /// Set notification preference of a user.
    /// </summary>
    /// <param name="currentUser">Current logged in user</param>
    /// <param name="preference">Notification preference</param>
    /// <returns>Task</returns>
    public Task SetNotificationPref(ApplicationUser currentUser, NotificationType preference)
    {
        currentUser.PreferredNotification = preference;
        return _accountDomainService.UpdateUser(currentUser);
    }


    /// <summary>
    /// Get list of technicians who chose Email as their preferred notification style
    /// </summary>
    /// <param name="preference">Notification preference</param>
    /// <returns>List of users</returns>
    public Task<List<ApplicationUser>> GetAllTechniciansWithNotiPref(NotificationType preference)
    {
        return _emailRepository.GetAccountByNotiPref(preference);
    }
}
