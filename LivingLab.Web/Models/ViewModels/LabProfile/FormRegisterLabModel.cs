using System.ComponentModel.DataAnnotations;
namespace LivingLab.Web.Models.ViewModels.LabProfile;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class FormRegisterLabModel
{

    [Required]
    [Display(Name = "LabLocation")]
    public string? LabLocation { get; set; }

    [Required]
    [Display(Name = "LabStatus")]
    public string? LabStatus { get; set; }

    [Required]
    [Display(Name = "LabInCharge")]
    public string? LabInCharge { get; set; }

    [Required]
    [Display(Name = "Capacity")]
    public int? Capacity { get; set; }

    [Required]
    [Display(Name = "Area")]
    public int Area { get; set; }

    [Display(Name = "EnergyUsageBenchmark")]
    public Double? EnergyUsageBenchmark { get; set; } = 0.0;


}
