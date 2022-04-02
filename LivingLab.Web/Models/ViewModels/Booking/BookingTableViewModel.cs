namespace LivingLab.Web.Models.ViewModels.Booking;
///<summary> What is a ViewModel
///The View Model refers to the objects which hold the data that needs to be shown to the user.
///The View Model is related to the presentation layer of our application. They are defined based on how the data is presented to the user rather than how they are stored.
/// <summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class BookingTableViewModel
{
    public int? LabNo { get; set; }
    
    public string? StartTime { get; set;}
    
    public string? Description { get; set;}
    
    public string? EndTime { get; set;}
     public int? BookId { get; set;}
}
