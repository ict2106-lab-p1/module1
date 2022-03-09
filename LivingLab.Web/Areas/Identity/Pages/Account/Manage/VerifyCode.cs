// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using LivingLab.Core.Entities.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace LivingLab.Web.Areas.Identity.Pages.Account.Manage;

public class VerifyCodeModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    // private readonly SignInManager<ApplicationUser> _OTPManager;

    private string twilioAccountSid = "AC7ef3169ab7a740f0ebb42a0643a5be7b";
    private string twilioAuthToken = "47bb78768eb244afcfed07d50e70a637";
    private string twilioMessagingServiceSid = "MG7d7cd6b53ca04365964a61a99448d3e0";
    private int OTP = 000000;

    private string answer;


    public VerifyCodeModel(
        UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [TempData]
    public string StatusMessage { get; set; }

    [TempData]
    public string StatusMessage2 { get; set; }

    [BindProperty]
    public string PinNumber { get; set; }

    [BindProperty]
    public string PhoneNumber { get; set; }

    public string BindPin { get; set; }

    private async Task LoadAsync(ApplicationUser user)
    {
        answer = await _userManager.GetPhoneNumberAsync(user);
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }
        
        var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
        

            if(PinNumber == phoneNumber){
            StatusMessage2 = "2FA Set-Up Succesfully";
        }else{
            StatusMessage2 = "Incorrect OTP";
        }
        
        await _signInManager.RefreshSignInAsync(user);
        
        return Page();
        
    }
}
