using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

namespace LivingLab.Core.Entities.Identity;

public class ApplicationUser : IdentityUser
{
    // Add additional profile data for application users by adding properties to this class
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? AuthenticationType { get; set; }
    [DataType(DataType.DateTime)]
    public string? SMSExpiry { get; set; }
    public string? UserFaculty { get; set; }
    
    public List<Booking> Bookings { get; set; }
    public List<Lab> Labs { get; set; }
    
    public List<LabAccess> LabAccesses { get; set; }
}
