using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels.LivingLabDashboard;
using LivingLab.Web.UIServices.LabProfile;
using LivingLab.Web.UIServices.LivingLabDashboard;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILabProfileService _labProfileService;
    private readonly ILivingLabDashboardService _dashboardService;

    public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILabProfileService labProfileService, ILivingLabDashboardService dashboardService)
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
        _labProfileService = labProfileService;
        _dashboardService = dashboardService;
    }

    /// <summary>
    /// Reroute the users to the login page
    /// </summary>
    /// <returns>Redirects to login</returns>
    [AllowAnonymous]
    [Route("/")]
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Login");
    }

    /// <summary>
    /// 1. Retrieve data needed for main dashboard
    /// 2. Direct all users to the main dashboard
    /// 3. Populate information on dashboard
    /// </summary>
    /// <returns>Populate LivingLabDashboardViewModel into the dashboard</returns>
    [Authorize(Roles = "User,Labtech,Admin")]
    public async Task<IActionResult> Dashboard()
    {
        var labLists = await _labProfileService.GetAllLabAccounts();
        var usageList = await _dashboardService.GetUsages();
        LivingLabDashboardViewModel viewLabs = new LivingLabDashboardViewModel()
        {
            LabList = labLists,
            Usages = usageList
        };
        return View("Dashboard", viewLabs);
    }

    /// <summary>
    /// 1. Logouts the user
    /// 2. Remove credentials from http context
    /// 3. Redirects to login page
    /// </summary>
    /// <returns>Login Page</returns>
    [Authorize(Roles = "User,Labtech,Admin")]
    public IActionResult Logout()
    {
        _logger.LogInformation("Logging out");
        //Delete the Session object.
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        _signInManager.SignOutAsync();
        HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies");
        return RedirectToAction("Index", "Login");
    }

    /// <summary>
    /// 1. Simple redirect to access denied page
    /// </summary>
    /// <returns>Access Denied Page</returns>
    [AllowAnonymous]
    public IActionResult AccessDenied()
    {
        return View("_AccessDenied");
    }

    /// <summary>
    /// 1. Retrieve lab lists
    /// 2. Generate the HTML for the navigation bar to populate lab list
    /// </summary>
    /// <returns>Return list of HTML elements for creating labs</returns>
    public async Task<IActionResult> GetLabs()
    {
        var renderList = "";
        var listOfLabs = await _labProfileService.GetAllLabAccounts();
        foreach (var lab in listOfLabs)
        {
            renderList += "<li><a href=\"/ViewLab/" + lab.LabLocation +
                          "\" class=\"hover:translate-x-2 transition-transform ease-in duration-300 w-full flex items-center h-10 pl-4 cursor-pointer\"><span>" +
                          lab.LabLocation + "</span></a></li>\n";
        }
        //query database, and get the data.
        return Json(renderList);
    }

    /// <summary>
    /// 1. Retrieve lab lists
    /// 2. Check if the labstechs are in charge of that particular lab
    /// 3. Generate the HTML for the navigation bar to populate review equipment
    /// </summary>
    /// <returns>Return list of HTML elements for creating review equipments</returns>
    public async Task<IActionResult> GetReviewEquipment()
    {
        var renderList = "";
        var user = await _userManager.GetUserAsync(User);
        var listOfLabs = await _labProfileService.GetAllLabAccounts();
        foreach (var lab in listOfLabs)
        {
            if (user.Id == lab.LabInCharge)
            {
                renderList += "<li><a href=\"/Equipment/ReviewEquipment/" + lab.LabLocation +
                              "\" class=\"hover:translate-x-2 transition-transform ease-in duration-300 w-full flex items-center h-10 pl-4 cursor-pointer\"><span>" +
                              lab.LabLocation + "</span></a></li>\n";
            }

        }

        if (renderList == "")
        {
            renderList =
                "<a class=\"hover:translate-x-2 transition-transform ease-in duration-300 w-full flex items-center h-10 pl-4 cursor-pointer\"><span>Not Lab In Charge</span></a>";
        }
        //query database, and get the data.
        return Json(renderList);
    }

}
