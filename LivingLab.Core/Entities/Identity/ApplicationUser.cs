using Microsoft.AspNetCore.Identity;

namespace LivingLab.Core.Entities.Identity;

public class ApplicationUser : IdentityUser
{
    // Add additional profile data for application users by adding properties to this class
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    // NotificationEmails and NotificationSMS references are required
    // to force Entity Framework to recognize the many-to-many relationship
    // but based on our design, applicationuser should not hold reference to notification messages
    // so they have been made private
    private List<EmailLog> NotificationEmails { get; set; } = new List<EmailLog>();
    private List<SmsLog> NotificationSmses { get; set; } = new List<SmsLog>();
}
