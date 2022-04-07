using System.ComponentModel.DataAnnotations;
namespace LivingLab.Web.Models.ViewModels.Account;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class ForgotPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

}
