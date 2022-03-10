using LivingLab.Web.Controllers.Api;
using LivingLab.Web.UIServices.Account;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class AccountController: BaseApiController
{
    private readonly IAccountService _accountService;
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
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
