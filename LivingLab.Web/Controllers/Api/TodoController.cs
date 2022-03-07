using LivingLab.Web.Models.DTOs.Todo;
using LivingLab.Web.UIServices.Todo;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Api;

public class TodoController : BaseApiController
{
    private readonly ITodoService _todoService;
    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    // GET: api/Todo
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _todoService.GetAllTodosAsync());
    }

    // GET: api/Todo/5
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        return Ok(_todoService.GetTodoAsync(id));
    }

    // POST: api/Todo
    [HttpPost]
    public async Task<IActionResult> Post(CreateTodoDTO todo)
    {
        try
        {
            return Ok(await _todoService.CreateTodoAsync(todo));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
