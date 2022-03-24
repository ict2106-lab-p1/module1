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
    
    [Required]
    public string? LabLocation { get; set; }

    [Required]
    public string? LabStatus { get; set; }

    public string? LabInCharge { get; set; }

    // [Required]
    // public int? Capacity { get; set; }
    //
    // public int? Area { get; set; }
    
    public Double? EnergyUsageBenchmark { get; set; }

    public List<Booking> Bookings { get; set; }

    public ApplicationUser ApplicationUser { get; set; }

    public List<SessionStats>? Logs { get; set; }
    public List<Accessory>? Accessories { get; set; }

    public List<Device>? Devices { get; set; }

}
