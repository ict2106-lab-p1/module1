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

    /// <summary>
    /// Redirect the user to login page
    /// </summary>
    /// <returns>Login Page</returns>
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Check if user credentials entered is correct
    /// 2. Go to OTP session if true
    /// </summary>
    /// <param name="loginDetails">Username and Password</param>
    /// <returns></returns>
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

    /// <summary>
    /// Reroutes user to verify OTP via email
    /// </summary>
    /// <returns>VerifyCodeEmail</returns>    
    [Authorize]
    /*User routes to verify code*/
    public IActionResult VerifyCodeEmail()
    {
        return View("VerifyCodeEmail");
    }

    /// <summary>
    /// User has to go to their email to verify 6 digit code
    /// Check if user entered the correct OTP on email page
    /// </summary>
    /// <param name="validationCode">OTP code</param>
    /// <returns>Redirect to Dashboard Page</returns>
    [HttpPost]
    public async Task<ActionResult> VerifyCodeEmail(VerifyViewModel validationCode)
    {
        // Get the User after the user has logged in
        ApplicationUser user = await _userManager.GetUserAsync(User);
        var result = await _accountService.VerifyCode(user.Id, validationCode.OTP);
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

    /// <summary>
    /// Generate new OTP for user via email
    /// </summary>
    /// <returns>Generates a new sms OTP</returns>
    [Authorize]
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

    /// <summary>
    /// 1. Route user to reset password Page
    /// 2. Check if token or email exist
    /// </summary>
    /// <param name="token">EF core token</param>
    /// <param name="email">Valid email</param>
    /// <returns></returns>
    [Authorize]
    public IActionResult VerifyCodeSMS()
    {
        return View("VerifyCodeSMS");
    }

    /// <summary>
    /// 1. Check if user has fill the viewModel
    /// 2. Reset the password for the user
    /// </summary>
    /// <param name="model">Reset password and confirmed password</param>
    /// <returns>Goes to Confirmation Page if password resetted</returns>
    [HttpPost]
    public async Task<ActionResult> VerifyCodeSMS(VerifyViewModel validationCode)
    {
        ApplicationUser user = await _userManager.GetUserAsync(User);
        var result = await _accountService.VerifyCode(user.Id, validationCode.OTP);
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

    /// <summary>
    /// 1. Goes to Password Recovery Page
    /// </summary>
    /// <returns>return forgot password</returns>
    [Authorize]
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
    public Task<ViewResult> ForgotPassword()
    {
        return Task.FromResult(View("_ForgotPassword"));
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
                var passwordResetLink = Url.Action("ResetPassword", "Login", new { email = model.Email, token = token },
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

        return View("_ForgotPassword", model);
    }

    [AllowAnonymous]
    /*Contact admin page if user lost their email / phone number*/
    public Task<ViewResult> ContactAdmin()
    {
        return Task.FromResult(View("_ContactAdmin"));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
