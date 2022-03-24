using System.ComponentModel.DataAnnotations;

using LivingLab.Core.Entities;

namespace LivingLab.Web.Models.ViewModels.UserManagement;
///<summary> What is a ViewModel
///The View Model refers to the objects which hold the data that needs to be shown to the user.
///The View Model is related to the presentation layer of our application. They are defined based on how the data is presented to the user rather than how they are stored.
/// <summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class UserManagementViewModel
{
    public string? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    private List<EmailLog> NotificationEmails { get; set; } = new List<EmailLog>();
    private List<SmsLog> NotificationSmses { get; set; } = new List<SmsLog>();
    public string? AuthenticationType { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime SMSExpiry { get; set; }
    public string? UserFaculty { get; set; }
    public List<Core.Entities.Booking> Bookings { get; set; }
    public List<Lab> Labs { get; set; }
    public List<LabAccess> LabAccesses { get; set; }

}
