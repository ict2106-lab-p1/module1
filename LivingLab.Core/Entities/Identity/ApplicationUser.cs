using Microsoft.AspNetCore.Identity;

namespace LivingLab.Domain.Entities.Identity;

public class ApplicationUser : IdentityUser
{
    // Add additional profile data for application users by adding properties to this class
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
