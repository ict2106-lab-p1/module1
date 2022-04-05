using System.ComponentModel.DataAnnotations;

namespace LivingLab.Web.Models.ViewModels.Account;

public class ForgotPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
}
