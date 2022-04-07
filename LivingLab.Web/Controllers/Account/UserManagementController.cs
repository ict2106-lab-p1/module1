using LivingLab.Web.Models.ViewModels.UserManagement;
using LivingLab.Web.UIServices.UserManagement;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Account;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
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

    /// <summary>
    /// 1. Get all user accounts
    /// 2. Map to view model
    /// 3. Return user accounts index
    ///  <param name="userId">UserID</param>
    ///  </summary>
    [Route("index")]
    public async Task<IActionResult> UserAccounts(string Id)
    {
        ViewUserManagementViewModel ViewUserManagementVM = await _userManagementService.GetAllAccounts();
        return View("Index", ViewUserManagementVM);
    }

    /// <summary>
    /// 1. View user details of selected user
    /// 2. Map to view model
    /// 3. Return user
    ///  <param name="userId">UserID</param>
    ///  </summary>
    [Route("View/{id}")]
    public async Task<UserManagementViewModel> ViewUserDetails(string Id)
    {
        //retrieve data from db
        UserManagementViewModel User = await _userManagementService.ViewUserDetails(Id);
        return User;
    }

    /// <summary>
    /// 1. Edit user details of selected user
    /// 2. Map to view model
    /// 3. Return user
    ///  <param name="editAccount">Retrieve relevant attributes</param>
    ///  </summary>
    [HttpPost("View/Edit")]
    public async Task<IActionResult> EditUser(UserManagementViewModel EditAccount)
    {
        await _userManagementService.EditAccount(EditAccount);

        ViewUserManagementViewModel ViewAcconts = await _userManagementService.GetAllAccounts();
        return View("Index", ViewAcconts);
    }

    /// <summary>
    /// 1. Delete user details of selected user
    /// 2. Map to view model
    /// 3. Return user
    ///  <param name="deleteAccount">Delete account</param>
    ///  </summary>
    [HttpPost("View/Delete")]
    public async Task<IActionResult> DeleteAccount(UserManagementViewModel DeleteAccount)
    {


        await _userManagementService.DeleteAccount(DeleteAccount);
        ViewUserManagementViewModel ViewAcconts = await _userManagementService.GetAllAccounts();
        return View("Index", ViewAcconts);



    }
}
