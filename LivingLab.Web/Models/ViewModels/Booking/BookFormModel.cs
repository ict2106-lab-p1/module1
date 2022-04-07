using System.ComponentModel.DataAnnotations;

using LivingLab.Core.Entities.Identity;

namespace LivingLab.Web.Models.ViewModels.Booking;
/// <summary> What is a ViewModel
/// The View Model refers to the objects which hold the data that needs to be shown to the user.
/// The View Model is related to the presentation layer of our application. They are defined based on how the data is presented to the user rather than how they are stored.
/// </summary>
/// 
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class BookFormModel
{


    public List<Core.Entities.Booking>? Bookings { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }

    public List<Core.Entities.SessionStats>? Logs { get; set; }
    public List<Core.Entities.Accessory>? Accessories { get; set; }

    public List<Core.Entities.Device>? Devices { get; set; }

    [Required]
    [Display(Name = "Lab")]
    public int LabId { get; set; }

    [Required]
    [Display(Name = "StartTime")]
    public DateTime StartTime { get; set; }

    [Required]
    [Display(Name = "EndTime")]
    public DateTime EndTime { get; set; }

    [Required]
    [Display(Name = "Description")]
    public String? Description { get; set; }

}
