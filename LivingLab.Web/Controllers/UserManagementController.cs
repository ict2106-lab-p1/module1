using LivingLab.Web.Controllers.Api;
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
    private readonly IUserManagementService _userManagementService;
    public UserManagementController(IUserManagementService userManagementService)
    {
        _userManagementService = userManagementService;
    }
    

    [Route("index")]
    public IActionResult UserBookings()
    {
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
