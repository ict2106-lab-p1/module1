using System.Diagnostics;

using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Notifications;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Account;
using LivingLab.Web.UIServices.Account;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Account;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    private readonly ILogger<AccountController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailNotifier _emailSender;

    public AccountController(IEmailNotifier emailSender, IAccountService accountService, ILogger<AccountController> logger, UserManager<ApplicationUser> userManager)
    {
        _accountService = accountService;
        _logger = logger;
        _userManager = userManager;
        _emailSender = emailSender;
    }

    /// <summary>
    /// Admin can access this page
    /// </summary>
    /// <returns>Register User Page</returns>
    public IActionResult Register()
    {
        return View("Register");
    }

    /// <summary>
    /// 1. Check if model form is filled / valid
    /// 2. Change the localhost to web domain if not localhost
    /// 3. Create a new user
    /// 4. Generate token and url string to user
    /// 4. Send a confirmation email to user
    /// 5. Return to successful account creation
    /// </summary>
    /// <param name="registration">RegisterViewModel form</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ViewResult> Register(RegisterViewModel registration)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var model = await _accountService.NewUser(registration);
                if (model != null)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(model);
                    if (Url.IsLocalUrl(Request.Headers["Referer"].ToString()))
                    {
                        HttpContext.Request.Host = HostString.FromUriComponent("livinglab.amatsuka.me");
                    }
                    var callbackUrl = Url.Action(
                        "ConfirmEmail", "Account",
                        new { userId = model.Id, token = token },
                        protocol: Request.Scheme);

                    await _userManager.AddToRoleAsync(model, registration.Role);
                    await _emailSender.SendEmailAsync(registration.Email,
                        "Confirm Living Lab Account",
                        "Dear " + registration.FirstName + ", <br> Living Lab Admin " + model.FirstName + " has registered an account on your behalf. <br>" +
                        "Your username is: " + registration.Email + "<br>" +
                        "Your password is: " + registration.Password + " <br>" +
                        "Please confirm your account by clicking this link: <a href=\""
                        + callbackUrl + "\">link</a>");
                }
                return View("_CheckEmail");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View(nameof(Register), registration);
            }
        }
        else
        {
            _logger.LogInformation("test");
            return View(nameof(Register), registration);
        }
    }

    /// <summary>
    /// 1. New User/Labtech/Admin has to confirm email with the email confirmation link
    /// 2. Authenticates the user by confirming the email (adding 1 to the repository)
    /// 3. Redirect to login
    /// </summary>
    /// <param name="userId">String GUID of User</param>
    /// <param name="token">Token generated from EF core</param>
    /// <returns>Fail To Confirm Email Page</returns>
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmEmail(string? userId, string? token)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
            return View("_FailConfirmEmail");
        }
        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            return View("_ConfirmEmail");
        }
        ViewBag.ErrorTitle = "Email cannot be confirmed";
        return View("Error");
    }

    /// <summary>
    /// 1. Load user information to see if email or sms is configured, return user phone and email
    /// 2. Check user authentication preference
    /// 3. Populate settingsViewModel
    /// 4. Return settingsViewModel to Settings
    /// </summary>
    /// <returns>Settings Page with settingsViewModel configured</returns>
    [Authorize(Roles = "User, Labtech, Admin")]
    public async Task<ViewResult> Settings()
    {
        SettingsViewModel settingsViewModel = new SettingsViewModel();
        var user = await _userManager.GetUserAsync(User);
        settingsViewModel.Email = user.Email;
        settingsViewModel.PhoneNumber = user.PhoneNumber;
        if (user.AuthenticationType == "SMS")
        {
            settingsViewModel.SMSAuth = true;
        }
        else if (user.AuthenticationType == "Email")
        {
            settingsViewModel.GoogleAuth = true;
        }
        return View("Settings", settingsViewModel);
    }

    /// <summary>
    /// 1. User reconfigure their settings
    /// 2. Settings is saved to database
    /// 3. Will only allow 1 method
    /// </summary>
    /// <param name="settingsViewModel">Get settingsViewModel data</param>
    /// <returns>Settings Page</returns>
    [HttpPost]
    [Authorize(Roles = "User,Admin,Labtech")]
    /*User can select their 2 fa option*/
    public async Task<RedirectToActionResult> SetUp2FA(SettingsViewModel settingsViewModel)
    {
        ApplicationUser user = await _userManager.GetUserAsync(User);

        if (settingsViewModel.SMSAuth)
        {
            _logger.LogInformation("Select SMS");
            user.AuthenticationType = "SMS";
            if (settingsViewModel.PhoneNumber != user.PhoneNumber)
            {
                user.PhoneNumber = settingsViewModel.PhoneNumber;
            }
        }
        else if (settingsViewModel.GoogleAuth)
        {
            _logger.LogInformation("Select Email");
            user.AuthenticationType = "Email";
            if (settingsViewModel.Email != user.Email)
            {
                user.Email = settingsViewModel.Email;
            }
        }
        else
        {
            _logger.LogInformation("Don't Select");
            user.AuthenticationType = "None";
        }
        await _accountService.UpdateUserSettings(user);
        return RedirectToAction("Settings", "Account");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
