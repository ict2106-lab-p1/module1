using System.ComponentModel.DataAnnotations;

namespace LivingLab.Web.Models.ViewModels;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class LogItemViewModel
{
    public string? DeviceCategory { get; set; }
    
    [Display(Name = "Serial No.")]
    public string? DeviceSerialNo { get; set; }

    [Display(Name = "Energy Usage")]
    public double EnergyUsage { get; set; }

    [Display(Name = "Interval (mins)")]
    public int Interval { get; set; }

    [Display(Name = "Logged At")]
    public DateTime LoggedDate { get; set; }
}
