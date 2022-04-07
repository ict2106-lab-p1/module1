using System.ComponentModel.DataAnnotations;
namespace LivingLab.Web.Models.ViewModels.Login;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }

    [Required]
    [Display(Name = "One-Time Password")]
    public int OTP { get; set; }
}
