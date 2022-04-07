using LivingLab.Core.DomainServices.Account;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Notifications;
using LivingLab.Web.Models.ViewModels.Account;
using LivingLab.Web.UIServices.NotificationManagement;

using Microsoft.AspNetCore.Identity;
namespace LivingLab.Web.UIServices.Account;
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
    private readonly IEmailNotifier _emailSender;

    public AccountService(IUserStore<ApplicationUser> userStore,
        UserManager<ApplicationUser> userManager,
        ILogger<AccountService> logger,
        SignInManager<ApplicationUser> signInManager,
        IAccountDomainService accountDomainService,
        INotificationManagementService notif,
        IEmailNotifier emailSender)
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

    /// <summary>
    /// 1. Create the EF user account
    /// 2. Add the rest of the information into a wrapper
    /// 3. Update to accountDomainService with UpdateUser function
    /// </summary>
    /// <param name="input">RegisterViewModel form</param>
    /// <returns>ApplicationUser object of new user</returns>
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
            user.PreferredNotification = 0;
            user.AuthenticationType = "None";
            user.PhoneNumber = input.PhoneNumber;
            return await _accountDomainService.UpdateUser(user);
        }
        return user;

    }

    /// <summary>
    /// 1.Call the accountDomainService GenerateCode
    /// 2. Check the code generated with EF library
    /// 3. Call the SMS service to send the user an OTP
    /// </summary>
    /// <param name="user">ApplicationUser object</param>
    /// <returns>Return status of this task</returns>
    public async Task<bool> GenerateCodeSMS(ApplicationUser user)
    {
        if (await _accountDomainService.GenerateCode(user))
        {
            try
            {
                ApplicationUser userDetails = await _userManager.FindByIdAsync(user.Id);
                string msgBody = "Your 6 digit OTP for Living Lab is " + userDetails.OTP;
                await _notif.SendTextToPhone("+65" + userDetails.PhoneNumber, msgBody);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        return false;
    }

    /// <summary>
    /// 1.Call the accountDomainService GenerateCode
    /// 2. Check the code generated with EF library
    /// 3. Call the Email service to send the user an OTP
    /// </summary>
    /// <param name="user">ApplicationUser object</param>
    /// <returns>Return status of this task</returns>
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
            catch (Exception)
            {
                return false;
            }
        }

        return false;
    }

    /// <summary>
    /// Check if the code entered is correct
    /// </summary>
    /// <param name="userid">String GUID of user</param>
    /// <param name="viewModel">VerifyViewModel OTP form</param>
    /// <returns></returns>
    public async Task<bool> VerifyCode(string userid, int OTP)
    {
        return await _accountDomainService.VerifyCode(userid, OTP);
    }

    /// <summary>
    /// Update user preferences
    /// </summary>
    /// <param name="user">ApplicationUser object</param>
    public async Task UpdateUserSettings(ApplicationUser user)
    {
        await _accountDomainService.UpdateUser(user);
    }

    /// <summary>
    /// EF core function to create a new user
    /// </summary>
    /// <returns>ApplicationUser object</returns>
    /// <exception cref="InvalidOperationException"></exception>
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

    /// <summary>
    /// Function to store email to user manager
    /// </summary>
    /// <returns>EF Core userStore</returns>
    /// <exception cref="NotSupportedException"></exception>
    private IUserEmailStore<ApplicationUser> GetEmailStore()
    {
        if (!_userManager.SupportsUserEmail)
        {
            throw new NotSupportedException("The default UI requires a user store with email support.");
        }
        return (IUserEmailStore<ApplicationUser>)_userStore;
    }
}
