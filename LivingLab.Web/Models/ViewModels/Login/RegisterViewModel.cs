
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LivingLab.Web.Models.ViewModels.Login;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class RegisterViewModel
{
    [Required(ErrorMessage = "Please enter a valid email address")]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Please enter a valid first name")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Please enter a valid last name")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Please enter a valid phone number")]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
    
    public bool IsSMS { get; set; }
    
    public bool IsGoogleAuth { get; set; }
    
    [Required]
    [Display(Name = "Password")]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string Password { get; set; }
    
    [Required]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }

    [Required]
    [Display(Name = "Select Faculty")]
    public string Faculty { get; set; }
    
    [Display(Name = "Select Role Of User")]
    public string Role { get; set; }
}
