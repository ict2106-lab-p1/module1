using System.ComponentModel.DataAnnotations;
namespace LivingLab.Web.Models.ViewModels.Account;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class SettingsViewModel
{
    [EmailAddress]
    public string? Email { get; set; }

    public bool GoogleAuth { get; set; }

    public string? PhoneNumber { get; set; }

    public bool SMSAuth { get; set; }
}
