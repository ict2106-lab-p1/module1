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
    
    public AccountService( IUserStore<ApplicationUser> userStore, IEmailSender emailSender, UserManager<ApplicationUser> userManager, ILogger<AccountService> logger, SignInManager<ApplicationUser> signInManager, IAccountDomainService accountDomainService)
    {
        _signInManager = signInManager;
        _accountDomainService = accountDomainService;
        _logger = logger;
        _userManager = userManager;
        _userStore = userStore;
        _emailStore = GetEmailStore();
;
    }


    public async Task<int> Login(LoginViewModel user)
    {
        int value = 0;
        
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                value = 200;

            }
            else
            {
                value = -1;
            }
            

        return value;
    }

    public async Task<ApplicationUser?> UpdateUser(RegisterViewModel input)
    {
        string Auth = "";
        if (input.IsGoogleAuth)
        {
            Auth = "Google";
        }
        else if (input.IsSMS)
        {
            Auth = "SMS";
        }
        else
        {
            Auth = "None";
        }

        ApplicationUser userDetails = await _userManager.FindByEmailAsync(input.Email);

        userDetails.FirstName = input.FirstName;
        userDetails.LastName = input.LastName;
        userDetails.AuthenticationType = Auth;
        userDetails.OTP = 000000;
        userDetails.UserFaculty = input.Faculty;
        userDetails.PhoneNumber = input.PhoneNumber;

        // ApplicationUser input = ApplicationUser(Id, user.FirstName, user.LastName, Auth, "",
        //     SMSTime, user.StudentFaculty, user.Email, user.Email.ToUpper(), user.Email,
        //     user.Email.ToUpper(), EmailConfirmed, PasswordHasher<>, SecurityStamp<>, ConcurrencyStamp,
        //     user.PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, "", LockoutEnabled, AccessFailedCount);
        
        return await _accountDomainService.UpdateUser(userDetails);
    }

    public async Task<ApplicationUser?> NewUser(RegisterViewModel input)
    {
        var user = CreateUser();

        await _userStore.SetUserNameAsync(user, input.Email, CancellationToken.None);
        await _emailStore.SetEmailAsync(user, input.Email, CancellationToken.None);
        var result = await _userManager.CreateAsync(user, input.Password);

        if (result.Succeeded)
        {
            _logger.LogInformation("User created a new account with password.");

            var userId = await _userManager.GetUserIdAsync(user);
            // var userDetails = await _userManager.FindByIdAsync(userId);

            user.UserFaculty = input.Faculty;
            user.LastName = input.LastName;
            user.FirstName = input.FirstName;
            if (input.IsGoogleAuth)
            {
                user.AuthenticationType = "Google";
            }
            else
            {
                user.AuthenticationType = "SMS";
            }

            user.PhoneNumber = input.PhoneNumber;

            return await _accountDomainService.UpdateUser(user);

        }
        return user;

    }

    public async Task<bool> GenerateCode(ApplicationUser user)
    {
        return await _accountDomainService.GenerateCode(user);
    }

    public async Task<bool> VerifyCode(string userid, VerifyViewModel viewModel)
    {
        return await _accountDomainService.VerifyCode(userid, viewModel.OTP);
    }

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
    private IUserEmailStore<ApplicationUser> GetEmailStore()
    {
        if (!_userManager.SupportsUserEmail)
        {
            throw new NotSupportedException("The default UI requires a user store with email support.");
        }
        return (IUserEmailStore<ApplicationUser>)_userStore;
    }
}
