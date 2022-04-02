using System.ComponentModel.DataAnnotations;

using LivingLab.Core.Entities.Identity;

namespace LivingLab.Web.Models.ViewModels.LabProfile;

public class LabRegisterViewModel
{
    public IList<ApplicationUser> LabICList { get; set; }
    [Required]
    [Display(Name = "LabLocation")]
    public string LabLocation { get; set; }
    
    [Display(Name = "LabStatus")]
    public string LabStatus { get; set; } = "Available";

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
