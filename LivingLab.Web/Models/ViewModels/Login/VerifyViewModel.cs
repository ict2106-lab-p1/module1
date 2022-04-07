using System.ComponentModel.DataAnnotations;
namespace LivingLab.Web.Models.ViewModels.Login;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class VerifyViewModel
{
    [Required]
    [Display(Name = "One-Time Password")]
    public int OTP { get; set; }
}
