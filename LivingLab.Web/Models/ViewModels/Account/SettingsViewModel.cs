using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Models.ViewModels.Account;

public class SettingsViewModel
{
    [EmailAddress]
    public string Email { get; set; }
    
    public bool GoogleAuth { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public bool SMSAuth { get; set; }
}
