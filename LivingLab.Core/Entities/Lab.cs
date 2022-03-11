using System.ComponentModel.DataAnnotations;

using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Entities;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class Lab
{
    [Key]
    public int LabId { get; set; }
<<<<<<< HEAD

    [Required]
    public string? LabLocation { get; set; }

    [Required]
    public string? LabStatus { get; set; }

    public string? LabInCharge { get; set; }

=======
    
    [Required]
    public string? LabLocation { get; set; }
    
    [Required]
    public string? LabStatus { get; set; }
    
    public string? LabInCharge { get; set; }
    
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
    [Required]
    public int? Capacity { get; set; }

    public List<Booking> Bookings { get; set; }
<<<<<<< HEAD

    public ApplicationUser ApplicationUser { get; set; }

=======
    
    public ApplicationUser ApplicationUser { get; set; }
    
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
    public List<SessionStats>? Logs { get; set; }
    public List<Accessory>? Accessories { get; set; }

    public List<Device>? Devices { get; set; }

}
