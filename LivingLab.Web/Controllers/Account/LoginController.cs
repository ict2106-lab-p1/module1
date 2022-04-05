using System.Diagnostics;

using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Account;
using LivingLab.Web.Models.ViewModels.Login;
using LivingLab.Web.UIServices.Account;
using LivingLab.Web.UIServices.NotificationManagement;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Account;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private readonly IAccountService _accountService;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly INotificationManagementService _notificationManagementService;


    public LoginController(ILogger<LoginController> logger,
        IAccountService accountService, SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager, INotificationManagementService notificationManagementService)
    {
        _logger = logger;
        _accountService = accountService;
        _signInManager = signInManager;
        _userManager = userManager;
        _notificationManagementService = notificationManagementService;
    }

    [AllowAnonymous]
    [HttpGet]
    /* Reroute the user to login page */
    public IActionResult Index()
    {
        return View();
    }

    /*Login if user details is true*/
    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel? loginDetails)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (loginDetails == null)
                {
                    return View(nameof(Index), new LoginViewModel());
                }
                var result = await _signInManager.PasswordSignInAsync(loginDetails?.Email, loginDetails?.Password,
                    loginDetails!.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(loginDetails.Email);

                    _logger.LogInformation(user.ToString());
                    
                    if (user.AuthenticationType != null && user.AuthenticationType.Contains("SMS"))
                    {
                        _logger.LogInformation("Verify Code");
                        await _accountService.GenerateCodeSMS(user);
                        
                        return RedirectToAction("verifycodesms", "Login");
                    }
                    else if (user.AuthenticationType != null && user.AuthenticationType.Contains("Email"))
                    {
                        _logger.LogInformation("Email Auth");
                        await _accountService.GenerateCodeEmail(user);
                        return RedirectToAction("verifycodeemail", "Login");
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Home");
                    }
                }
                else
                {
                    _logger.LogInformation("Fail to login");
                    ModelState.AddModelError(nameof(loginDetails.Password), "Password entered wrongly");
                    return View("Index", new LoginViewModel());
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
    /*User routes to verify code*/
    public IActionResult VerifyCodeEmail()
    {
        return View("VerifyCodeEmail");
    }

    [HttpPost]
    /* User has to go to their email to verify 6 digit code */
    public async Task<ActionResult> VerifyCodeEmail(VerifyViewModel validationCode)
    {
        // Get the User after the user has logged in
        ApplicationUser user = await _userManager.GetUserAsync(User);
        var result = await _accountService.VerifyCode(user.Id, validationCode);
        if (result)
        {
            return RedirectToAction("Dashboard", "Home");
        }
        else
        {
            ModelState.AddModelError(nameof(validationCode.OTP), "OTP has expired, please re-email new OTP");
            return View(validationCode);
        }
    }
    
    [Authorize]
    /*User routes to verify code*/
    public async Task<RedirectToActionResult> NewCodeEmail()
    {
        ApplicationUser user = await _userManager.GetUserAsync(User);
        if (await _accountService.GenerateCodeEmail(user))
        {
            return RedirectToAction(nameof(VerifyCodeEmail));
        }
        else
        {
            return RedirectToAction(nameof(VerifyCodeEmail));
        }
    }
    
    [Authorize]
    /* User can login with their SMS*/
    public IActionResult VerifyCodeSMS()
    {
        return View("VerifyCodeSMS");
    }

    [HttpPost]
    /*Logs in with the OTP generated by the SMS*/
    public async Task<ActionResult> VerifyCodeSMS(VerifyViewModel validationCode)
    {
        ApplicationUser user = await _userManager.GetUserAsync(User);
        var result = await _accountService.VerifyCode(user.Id, validationCode);
        if (result)
        {
            return RedirectToAction("Dashboard", "Home");
        }
        else
        {
            ModelState.AddModelError(nameof(validationCode.OTP), "OTP has expired, please generate new OTP");
            return View(validationCode);
        }
    }

    [Authorize]
    /*Generates a new sms OTP*/
    public async Task<RedirectToActionResult> NewCodeSMS()
    {
        ApplicationUser user = await _userManager.GetUserAsync(User);
        if (await _accountService.GenerateCodeSMS(user))
        {
            return RedirectToAction(nameof(VerifyCodeSMS));
        }
        else
        {
            return RedirectToAction(nameof(VerifyCodeSMS));
        }
    }

    [HttpGet]
    [AllowAnonymous]
    /*User can change their password on this page after clicking on their email link*/
    public IActionResult ResetPassword(string token, string email)
    {
        if (token == "" || email == "")
        {
            ModelState.AddModelError("", "Invalid password reset token");
        }

        return View("_ResetPassword");
    }

    [HttpPost]
    /*Allow users to change their password*/
    public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
    {
        _logger.LogInformation(model.Email, model.Token, model.Password);
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {
                    return View("_ResetPasswordConfirmation");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("_ResetPassword", model);
            }
            return View("_ResetPassword");
        }

        return View("_ResetPassword", model);
    }

    [HttpGet]
    /*Goes to the password recovery page*/
    public async Task<ViewResult> ForgotPassword()
    {
        return View("_ForgotPassword");
    }

    [HttpPost]
    [AllowAnonymous]
    /*Users can send a reset link using this post function*/
    public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.IsEmailConfirmedAsync(user))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResetLink = Url.Action("ResetPassword", "Login", new {email = model.Email, token = token},
                    Request.Scheme);
                _logger.Log(LogLevel.Warning, passwordResetLink);

                await _notificationManagementService.SendTextToEmail(model.Email, 
                    "Reset Password", 
                    "Please reset your password by clicking this link: <a href=\"" 
                    + passwordResetLink + "\">link</a>");

                return View("_ForgotPasswordConfirmation");
            }

            return View("_ForgotPasswordConfirmation");
        }

        return View("_ForgotPassword",model);
    }
    
    [AllowAnonymous]
    /*Contact admin page if user lost their email / phone number*/
    public async Task<ViewResult> ContactAdmin()
    {
        return View("_ContactAdmin");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
