using System.ComponentModel.DataAnnotations;

using LivingLab.Core.Entities.Identity;

namespace LivingLab.Web.Models.ViewModels.LabProfile;

public class LabRegisterViewModel
{
    [Required]
    [Display(Name = "LabLocation")]
    public string LabLocation { get; set; }
    
    public string LabStatus = "Available";

    public int Occupied = 0;
    
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
