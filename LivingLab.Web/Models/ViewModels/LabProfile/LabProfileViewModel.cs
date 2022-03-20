using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;

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

    public string? LabLocation { get; set; }

    public string? LabStatus { get; set; }

    public string? LabInCharge { get; set; }

    public int? Capacity { get; set; }

    public List<Core.Entities.Booking> Bookings { get; set; }

    public ApplicationUser ApplicationUser { get; set; }

    public List<SessionStats>? Logs { get; set; }
    public List<Core.Entities.Accessory>? Accessories { get; set; }

    public List<Core.Entities.Device>? Devices { get; set; }
}
