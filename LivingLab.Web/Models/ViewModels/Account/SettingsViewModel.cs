using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Models.ViewModels.Account;

public class SettingsViewModel
{
    [EmailAddress]
    [BindProperty]
    public string Email { get; set; }
    
    public bool GoogleAuth { get; set; }
    
    [BindProperty]
    public string PhoneNumber { get; set; }
    
    public bool SMSAuth { get; set; }
}
