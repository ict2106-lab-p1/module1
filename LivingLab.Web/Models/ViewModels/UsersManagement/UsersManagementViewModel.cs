namespace LivingLab.Web.Models.ViewModels.UsersManagement;
///<summary> What is a ViewModel
///The View Model refers to the objects which hold the data that needs to be shown to the user.
///The View Model is related to the presentation layer of our application. They are defined based on how the data is presented to the user rather than how they are stored.
/// <summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class UsersManagementViewModel
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Faculty { get; set; }
    public string AuthenticationType { get; set; }
    public bool TwoFactorEnabled  { get; set; }
    public string EncryptedPassword { get; set; }
    public DateTime SMSExpiry { get; set; }


}
