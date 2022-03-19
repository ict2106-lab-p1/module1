using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Web.Models.DTOs.Todo;
using LivingLab.Web.Models.ViewModels.Login;
using LivingLab.Web.UIServices.NotificationManagement;
using LivingLab.Web.UIServices.Todo;

using Microsoft.AspNetCore.Identity;

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
    private readonly ILogger<AccountService> _logger;
    
    public AccountService( ILogger<AccountService> logger, SignInManager<ApplicationUser> signInManager, IAccountDomainService accountDomainService)
    {
        _signInManager = signInManager;
        _accountDomainService = accountDomainService;
        _logger = logger;
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

    public async Task<ApplicationUser?> UpdateUser(string userid, RegisterViewModel user)
    {
        string Auth = "";
        if (user.IsGoogleAuth)
        {
            Auth = "Google";
        }
        else if (user.IsSMS)
        {
            Auth = "SMS";
        }
        else
        {
            Auth = "None";
        }
        // ApplicationUser input = ApplicationUser(Id, user.FirstName, user.LastName, Auth, "",
        //     SMSTime, user.StudentFaculty, user.Email, user.Email.ToUpper(), user.Email,
        //     user.Email.ToUpper(), EmailConfirmed, PasswordHasher<>, SecurityStamp<>, ConcurrencyStamp,
        //     user.PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, "", LockoutEnabled, AccessFailedCount);
        
        ApplicationUser input = new ApplicationUser
        {
            Id = userid,
            AccessFailedCount = 0,
            AuthenticationType = Auth,
            OTP = 0,
            UserFaculty = user.StudentFaculty,
            FirstName = user.FirstName,

        };
        return await _accountDomainService.UpdateUser(input);
    }

    public async Task<bool> GenerateCode(ApplicationUser user)
    {
        return await _accountDomainService.GenerateCode(user);
    }

    public async Task<bool> VerifyCode(string userid, VerifyViewModel viewModel)
    {
        return await _accountDomainService.VerifyCode(userid, viewModel.OTP);
    }

    public async Task<ApplicationUser?> Save(ApplicationUser user)
    {

        return await _accountDomainService.Save(user);
    }
}
