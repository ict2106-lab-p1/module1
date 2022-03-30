using System.ComponentModel.DataAnnotations;

namespace LivingLab.Web.Models.ViewModels.Login;

public class VerifyViewModel
{
    [Required]
    [Display(Name = "One-Time Password")]
    public int OTP { get; set; }
}
