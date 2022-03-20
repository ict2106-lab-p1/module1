using LivingLab.Web.Controllers.Api;
using LivingLab.Web.Models.ViewModels.UserManagement;
using LivingLab.Web.UIServices.UserManagement;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
///
/// 

[Route("userManagement")]
public class UserManagementController : Controller
{
    private readonly ILogger<UserManagementController> _logger;
    private readonly IUserManagementService _userManagementService;
    public UserManagementController(ILogger<UserManagementController> logger, IUserManagementService userManagementService)
    {
        _logger = logger;
        _userManagementService = userManagementService;
    }
    

    [Route("index")]
    public async Task<IActionResult> UserBookings(string userId)
    {
        ViewUserManagementViewModel viewUserManagementViewModel = await _userManagementService.GetAllAccounts();
        return View("Index", viewUserManagementViewModel); 
    }
    [Route("View/{id}")]
    public async Task<UserManagementViewModel> ViewUserDetails(string id)
    { 
        //retrieve data from db
        UserManagementViewModel user = await _userManagementService.ViewUserDetails(id);

        return user;
    }
    
    [HttpPost("View/Edit")]
    public async Task<IActionResult> EditUser(UserManagementViewModel editAccount)
    {
        //received data 
        Console.WriteLine("Email: "+ editAccount.Email);
        Console.WriteLine("ID: "+ editAccount.Id);
        await _userManagementService.EditAccount(editAccount);

        // Temp - To display ViewAll after editing
        ViewUserManagementViewModel viewAccounts = await _userManagementService.GetAllAccounts();
        return View("Index", viewAccounts);
    }
    
    [HttpPost("View/Delete")]
    public async Task<IActionResult> DeleteAccount(UserManagementViewModel deleteAccount)
    {
        Console.WriteLine("ID: "+ deleteAccount.Id);

        await _userManagementService.DeleteAccount(deleteAccount);

        ViewUserManagementViewModel viewAccounts = await _userManagementService.GetAllAccounts();
        return View("Index", viewAccounts);
    }
}
