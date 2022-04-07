using System.ComponentModel.DataAnnotations;

using LivingLab.Core.Enums;

using Microsoft.AspNetCore.Identity;

namespace LivingLab.Core.Entities.Identity;

/// <summary>
/// The Application user created by EF core, below are attributes added to the template IdentityUser
/// </summary>
///
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    private List<EmailLog>? NotificationEmails { get; set; }
    public NotificationType PreferredNotification { get; set; }
    public string? AuthenticationType { get; set; }
    public int? OTP { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime SMSExpiry { get; set; }
    public string? UserFaculty { get; set; }
    public List<Booking>? Bookings { get; set; }
    public List<Lab>? Labs { get; set; }
}
