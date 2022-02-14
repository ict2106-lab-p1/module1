using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Web.ApiModels;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.ApiControllers;

public class TodoController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly ITodoRepository _todoRepository;

    public TodoController(ITodoRepository todoRepository, IMapper mapper)
    {
        _mapper = mapper;
        _todoRepository = todoRepository;
    }

    // GET: api/Todo
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_todoRepository.GetAllAsync());
    }

    // GET: api/Todo/5
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        return Ok(_todoRepository.GetByIdAsync(id));
    }

    // POST: api/Todo
    [HttpPost]
    public async Task<IActionResult> Post(TodoDTO.CreateTodoDTO todo)
    {
        // Can replace with auto mappers in the future
        var newTodo = _mapper.Map<TodoDTO.CreateTodoDTO, Todo>(todo);

        var createdTodo = await _todoRepository.AddAsync(newTodo);

        var result = _mapper.Map<Todo, TodoDTO>(createdTodo);

        return Ok(result);
    }

}
