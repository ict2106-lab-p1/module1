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
    public async Task<IActionResult> UserBookings()
    {
        ViewUserManagementViewModel viewUserManagementViewModel = await _userManagementService.GetAllAccounts();
        return View("Index", viewUserManagementViewModel); 
    }

    [HttpPost("View/Delete")]
    public async Task<IActionResult> DeleteUser(UserManagementViewModel deleteAccount)
    {
        await _userManagementService.DeleteAccount(deleteAccount); 
        
        // ViewUserManagementViewModel viewAccounts =  await _userManagementService.DeleteAccount(deleteAccount); 

        return View("Index");
    }

    // // GET: api/Account
    // [HttpGet]
    // public async Task<IActionResult> GetAllAccount()
    // {
    //     return Ok(await _accountService.());
    // }

    // // GET: api/Account/"User1"
    // [HttpGet("{userId:string}")]
    // public IActionResult Get(string userId)
    // {
    //     return Ok(_todoService.GetTodoAsync(id));
    // }
    //
    // // POST: api/Todo
    // [HttpPost]
    // public async Task<IActionResult> Post(CreateTodoDTO todo)
    // {
    //     try
    //     {
    //         return Ok(await _todoService.CreateTodoAsync(todo));
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e.Message);
    //     }
    // }
    
}
