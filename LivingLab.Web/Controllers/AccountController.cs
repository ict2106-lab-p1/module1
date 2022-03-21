using System.Diagnostics;

using LivingLab.Core.Entities.Identity;
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
    public AccountController(IAccountService accountService, ILogger<AccountController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _accountService = accountService;
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public IActionResult Register()
    {
        return View("Register");
    }

    
    [HttpPost]
    public async Task<ViewResult> Register(RegisterViewModel registration)
    {
        if (ModelState.IsValid)
        {
            _logger.LogInformation("Logs all user input");
            try
            {
                var model = await _accountService.NewUser(registration);
                return View("Register", registration);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return View(nameof(Register),registration);
            }
        }
        else
        {
            _logger.LogInformation("Fail get all input");
            return View(nameof(Register),registration);
        }
    }

    [Route("settings")]
    public async Task<ViewResult> Settings(SettingsViewModel settingsViewModel)
    {
        ApplicationUser user = await _userManager.GetUserAsync(User);
        settingsViewModel.Email = user.Email;
        settingsViewModel.PhoneNumber = user.PhoneNumber;

        if (user.AuthenticationType == "SMS")
        {
            settingsViewModel.SMSAuth = true;
        }else if (user.AuthenticationType == "Google")
        {
            settingsViewModel.GoogleAuth = true;
        }
        return View("SMSAuth", settingsViewModel);
    }
    
    [HttpPost]
    public async Task<ViewResult> SetUp2FA(SettingsViewModel settingsViewModel)
    {
        ApplicationUser user = await _userManager.GetUserAsync(User);

        _logger.LogInformation("HENRY IS HERE");
        
        if (settingsViewModel.SMSAuth && settingsViewModel.GoogleAuth)
        {
            _logger.LogInformation("Cannot have two authentication methods");
            return View("SMSAuth", settingsViewModel);
        }
        else if (settingsViewModel.SMSAuth)
        {
            _logger.LogInformation("Select SMS");
            user.AuthenticationType = "SMS";
        }else if (settingsViewModel.GoogleAuth)
        {
            _logger.LogInformation("Select Email");
            user.AuthenticationType = "Google";
        }
        else
        {
            _logger.LogInformation("Don't Select");
            user.AuthenticationType = "None";
        }

        user.PhoneNumber = settingsViewModel.PhoneNumber;
        user.Email = settingsViewModel.Email;
        await _accountService.UpdateUserSettings(user);
        
        return View("SMSAuth", settingsViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
