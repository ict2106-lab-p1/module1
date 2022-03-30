using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace LivingLab.Web.Models.ViewModels.LabProfile;
///<summary> What is a ViewModel
///The View Model refers to the objects which hold the data that needs to be shown to the user.
///The View Model is related to the presentation layer of our application. They are defined based on how the data is presented to the user rather than how they are stored.
/// <summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileViewModel
{
    public int LabId { get; set; }
    
    public List<Core.Entities.Booking> Bookings { get; set; }

    public ApplicationUser ApplicationUser { get; set; }

    public List<Core.Entities.SessionStats>? Logs { get; set; }
    public List<Core.Entities.Accessory>? Accessories { get; set; }

    public List<Core.Entities.Device>? Devices { get; set; }
    [Required]
    [Display(Name = "LabLocation")]
    public string LabLocation { get; set; }
    
    [Required]
    [Display(Name = "LabStatus")]
    public string LabStatus { get; set; }
    
    [Required]
    [Display(Name = "LabInCharge")]
    public string LabInCharge { get; set; }
    
    [Required]
    [Display(Name = "Capacity")]
    public int Capacity { get; set; }
    
    [Required]
    [Display(Name = "Area")]
    public int Area { get; set; }

    [Display(Name = "EnergyUsageBenchmark")]
    public Double? EnergyUsageBenchmark { get; set; } = 0.0;
}
