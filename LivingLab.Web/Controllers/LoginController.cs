using System.Diagnostics;
using System.Security.Cryptography.Pkcs;

using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Login;
using LivingLab.Web.UIServices.Account;
using LivingLab.Web.UIServices.NotificationManagement;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-5
/// </remarks>

[Route("Login")]
public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly IAccountService _accountService;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly INotificationManagementService _notif;

    public LoginController(INotificationManagementService notif, ILogger<LoginController> logger, IAccountService accountService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _accountService = accountService;
        _signInManager = signInManager;
        _userManager = userManager;
        _notif = notif;

    }

    [HttpGet]
    [Route("Login")]
    public IActionResult Index()
    {
        return View("Index");
    }
    
    [Route("VerifyCode")]
    public IActionResult VerifyCode()
    {
        return View("VerifyCode");
    }
    
    [HttpPost]
    [Route("VerifyCode")]
    public async Task<RedirectToActionResult> VerifyCode(VerifyViewModel inputDetails)
    {
        ApplicationUser user = await _userManager.GetUserAsync(User);
        var result = await _accountService.VerifyCode(user.Id, inputDetails);
        if (result)
        {
            _logger.LogInformation("HENRY SUCCESS");
            return RedirectToAction("Index", "Home");
        }
        else
        {
            _logger.LogInformation("HENRY FAIL");
            return RedirectToAction("VerifyCode");

        }
        
    }
    
    [Route("NewCode")]
    public async Task<RedirectToActionResult> NewCode()
    {
        ApplicationUser user = await _userManager.GetUserAsync(User);
        var result = await _accountService.GenerateCode(user);
        if (result)
        {
            _logger.LogInformation("HENRY CHANGE CODE");
            await _notif.SendTextToPhone(user);
            return RedirectToAction("VerifyCode", "Login");
        }
        else
        {
            return RedirectToAction("NewCode");
        }
    }

    [Route("ForgotPassword")]
    public IActionResult ForgotPassword()
    {
        return Redirect("/Identity/Account/ForgotPassword");
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Index(LoginViewModel userDetails)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userDetails.Email, userDetails.Password, userDetails.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Go to Verify Code");
                    ApplicationUser user = await _userManager.GetUserAsync(User);
                    await _accountService.GenerateCode(user);
                    await _notif.SendTextToPhone(user);
                    return RedirectToAction("VerifyCode", "Login");
                }
                else
                {
                    _logger.LogInformation("Fail to login");
                    return View(userDetails);
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation("Failed to login");
                return View(userDetails);
            }
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

