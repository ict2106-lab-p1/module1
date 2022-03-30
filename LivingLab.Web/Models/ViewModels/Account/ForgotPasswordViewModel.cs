using System.ComponentModel.DataAnnotations;

namespace LivingLab.Web.Models.ViewModels.Login;

public class ForgotPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
}
