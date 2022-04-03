using System.Diagnostics;

using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Notifications;
using LivingLab.Web.Controllers.Api;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Account;
using LivingLab.Web.Models.ViewModels.Login;
using LivingLab.Web.UIServices.Account;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class AccountController: Controller
{
    private readonly IAccountService _accountService;
    private readonly ILogger<AccountController> _logger;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailNotifier _emailSender;

    public AccountController( IEmailNotifier emailSender, IAccountService accountService, ILogger<AccountController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _accountService = accountService;
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
        _emailSender = emailSender;

    }
    
    //TODO: Add [Authorize(Roles = "Admin")]
    [Route("register")]
    /*Admin can see this page and register*/
    public IActionResult Register()
    {
        return View("Register");
    }

    
    [HttpPost]
    [Route("register")]
    //TODO: Add [Authorize(Roles = "Admin")]
    /*Allow admin to register users*/
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
                    var callbackUrl = Url.Action(
                        "ConfirmEmail", "Account", 
                        new { userId = model.Id, token = token }, 
                        protocol: Request.Scheme);

                    await _userManager.AddToRoleAsync(model, registration.Role);

                    await _emailSender.SendEmailAsync(model.Email, 
                        "Confirm your account", 
                        "Please confirm your account by clicking this link: <a href=\"" 
                        + callbackUrl + "\">link</a>");
                }
                
                return View("_CheckEmail");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View(nameof(Register),registration);
            }
        }
        else
        {
            _logger.LogInformation("test");
            return View(nameof(Register),registration);
        }
    }

    [HttpGet]
    [Route("confirmemail")]
    [AllowAnonymous]
    /*Goes to confirm email page*/
    public async Task<IActionResult> ConfirmEmail(string? userId, string? token)
    {
        _logger.LogInformation(userId);

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
            return View(nameof(Register));
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            return View("_ConfirmEmail");
        }
        else
        {
            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("Error");
        }
    }

    [Authorize(Roles = "User,Labtech,Admin")]
    [Route("settings")]
    /*Show the settings page with properties binding*/
    public async Task<ViewResult> Settings(SettingsViewModel settingsViewModel)
    {
        var user = await _userManager.GetUserAsync(User);
        settingsViewModel.Email = user.Email;
        settingsViewModel.PhoneNumber = user.PhoneNumber;

        if (user.AuthenticationType == "SMS")
        {
            settingsViewModel.SMSAuth = true;
        }else if (user.AuthenticationType == "Email")
        {
            settingsViewModel.GoogleAuth = true;
        }
        return View("SMSAuth", settingsViewModel);
    }
    
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

        }else if (settingsViewModel.GoogleAuth)
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
