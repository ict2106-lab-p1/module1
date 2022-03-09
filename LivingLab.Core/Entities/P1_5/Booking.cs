using System.ComponentModel.DataAnnotations;

using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Entities;

public class Booking
{
    [Key]
    public int BookingId { get; set; }

    [Required]
    [DataType(DataType.Time)]
    public string? StartTime { get; set; }
    
    [Required]
    [DataType(DataType.Time)]
    public string? EndTime { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public string? StartDate { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public string? EndDate { get; set; }
    
    public string? Description { get; set; }
    
    [Required]
    public int LabId { get; set; }
    
    public Lab? Lab { get; set; }

    [Required]
    public string UserId { get; set; }
    
    public ApplicationUser? ApplicationUser { get; set; }

}

