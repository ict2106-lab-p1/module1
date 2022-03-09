namespace LivingLab.Domain.Entities.Identity;

using System.ComponentModel.DataAnnotations;

public class Booking : BaseEntity
{
    [Required]
    [DataType(DataType.Text)]
    public string? bookingId { get; set; }

    [Required]
    [DataType(DataType.Time)]
    public string? startTime { get; set; }
    
    [Required]
    [DataType(DataType.Time)]
    public string? endTime { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public string? startDate { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public string? endDate { get; set; }
    
    [Required]
    [DataType(DataType.Text)]
    public string? labId { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string? userId { get; set; }
    
}

