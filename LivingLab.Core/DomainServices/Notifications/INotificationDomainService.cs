using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Enums;

namespace LivingLab.Core.DomainServices.Notifications;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface INotificationDomainService
{
    [Obsolete("Old interface method that's not possible to implement. Use the newer parameterized version instead.")]
    Task<List<ApplicationUser>> GetAllTechniciansWithNotiPref(NotificationType preference);
    Task SetNotificationPref(ApplicationUser currentUser, NotificationType preference);
}
