using System.Diagnostics;
using System.Security.Cryptography.Pkcs;

using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Login;
using LivingLab.Web.UIServices.Account;
using LivingLab.Web.UIServices.NotificationManagement;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-5
/// </remarks>

[Route("login")]
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
    /* For route to /login */
    [Route("")] 
    public IActionResult Index()
    {
        return View();
    }
    
    /*Login if user details is true*/
    [HttpPost]
    public async Task<IActionResult> LoginUser(LoginViewModel userDetails)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userDetails.Email, userDetails.Password, userDetails.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    
                    ApplicationUser user = await _userManager.GetUserAsync(User);

                    _logger.LogInformation(user.AuthenticationType);

                    if (user.AuthenticationType.Contains("SMS"))
                    {
                        _logger.LogInformation("Verify Code");
                        await _accountService.GenerateCode(user);
                        await _notif.SendTextToPhone(user);
                        return RedirectToAction("verifycode", "Login");
                    }
                    else if (user.AuthenticationType.Contains("Google"))
                    {
                        _logger.LogInformation("Google Auth");
                        return View("Index");
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Home");
                    }


                }
                else
                {
                    _logger.LogInformation("Fail to login");
                    ModelState.AddModelError(nameof(userDetails.Password), "Password entered wrongly");
                    return View("Index",userDetails);
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.ToString());
                return View(nameof(Index));
            }
        }
        return View(nameof(Index));
    }
    
    [Authorize]
    /* For route to /login/verifycode */
    [Route("verifycode")]
    public IActionResult VerifyCode()
    {
        return View("VerifyCode");
    }
    
    [HttpPost]
    [Route("verifycode")]
    public async Task<ActionResult> VerifyCode(VerifyViewModel inputDetails)
    {
        ApplicationUser user = await _userManager.GetUserAsync(User);
        var result = await _accountService.VerifyCode(user.Id, inputDetails);
        if (result)
        {
            _logger.LogInformation("HENRY SUCCESS");
            return RedirectToAction("Dashboard", "Home");
        }
        else
        {
            _logger.LogInformation("HENRY FAIL");
            ModelState.AddModelError(nameof(inputDetails.OTP), "OTP has expired, please generate new OTP");
            return View(inputDetails);

        }
        
    }
    
    [Authorize]
    [Route("newcode")]
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

