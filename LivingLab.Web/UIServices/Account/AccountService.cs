using System.Security.Policy;

using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Web.Models.DTOs.Todo;
using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.Models.ViewModels.Login;
using LivingLab.Web.UIServices.NotificationManagement;
using LivingLab.Web.UIServices.Todo;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

using Twilio.Http;

using IEmailSender = LivingLab.Core.Interfaces.Services.IEmailSender;

namespace LivingLab.Web.UIServices.Account;
/// <summary>
/// This is a UI-specific service so it belongs in the Web project.
/// It does not contain any business logic and works with UI-specific types (view models and DTOs).
/// </summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class AccountService : IAccountService
{
    private readonly IAccountDomainService _accountDomainService;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<AccountService> _logger;
    private readonly IUserStore<ApplicationUser> _userStore;
    private readonly IUserEmailStore<ApplicationUser> _emailStore;
    private readonly INotificationManagementService _notif;
    private readonly IEmailSender _emailSender;
    
    public AccountService(IUserStore<ApplicationUser> userStore, 
        UserManager<ApplicationUser> userManager, 
        ILogger<AccountService> logger, 
        SignInManager<ApplicationUser> signInManager, 
        IAccountDomainService accountDomainService,
        INotificationManagementService notif,
        IEmailSender emailSender)
    {
        _signInManager = signInManager;
        _accountDomainService = accountDomainService;
        _logger = logger;
        _userManager = userManager;
        _userStore = userStore;
        _emailStore = GetEmailStore();
        _notif = notif;
        _emailSender = emailSender;
    }

    /*Registers a new user - Admin only*/
    public async Task<ApplicationUser?> NewUser(RegisterViewModel input)
    {
        var user = CreateUser();

        await _userStore.SetUserNameAsync(user, input.Email, CancellationToken.None);
        await _emailStore.SetEmailAsync(user, input.Email, CancellationToken.None);
        var result = await _userManager.CreateAsync(user, input.Password);

        if (result.Succeeded)
        {
            _logger.LogInformation("User created a new account with password.");

            user.UserFaculty = input.Faculty;
            user.LastName = input.LastName;
            user.FirstName = input.FirstName;
            if (input.IsGoogleAuth)
            {
                user.AuthenticationType = "Email";
            }
            else if (input.IsGoogleAuth)
            {
                user.AuthenticationType = "SMS";
            }
            else
            {
                user.AuthenticationType = "None";
            }

            user.PhoneNumber = input.PhoneNumber;

            return await _accountDomainService.UpdateUser(user);

        }
        return user;

    }

    /*Generate login OTP for SMS*/
    public async Task<bool> GenerateCodeSMS(ApplicationUser user)
    {
        if (await _accountDomainService.GenerateCode(user))
        {
            try
            {
                ApplicationUser userDetails = await _userManager.FindByIdAsync(user.Id);
                string msgBody = "Your 6 digit OTP for Living Lab is " + userDetails.OTP;
                await _notif.SendTextToPhone("+65"+userDetails.PhoneNumber, msgBody);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        return false;
    }

    /*Generates login OTP for email*/
    public async Task<bool> GenerateCodeEmail(ApplicationUser user)
    {
        if (await _accountDomainService.GenerateCode(user))
        {
            try
            {
                ApplicationUser userDetails = await _userManager.FindByIdAsync(user.Id);
                string emailHeader = "OTP for Living Lab";
                string msgBody = "Your 6 digit OTP for Living Lab is " + userDetails.OTP;
                await _emailSender.SendEmailAsync(userDetails.Email,
                    emailHeader,
                    msgBody);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        return false;
    }

    /*Verify if the OTP code is correct*/
    public async Task<bool> VerifyCode(string userid, VerifyViewModel viewModel)
    {
        return await _accountDomainService.VerifyCode(userid, viewModel.OTP);
    }

    /*Update user settings 2FA selection*/
    public async Task UpdateUserSettings(ApplicationUser user)
    {
        await _accountDomainService.UpdateUser(user);
    }

    /*Function from users manager to create users*/
    private ApplicationUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<ApplicationUser>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                                                $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                                                $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        }
    }
    
    /*Function to store email to user manager*/
    private IUserEmailStore<ApplicationUser> GetEmailStore()
    {
        if (!_userManager.SupportsUserEmail)
        {
            throw new NotSupportedException("The default UI requires a user store with email support.");
        }
        return (IUserEmailStore<ApplicationUser>)_userStore;
    }
}
