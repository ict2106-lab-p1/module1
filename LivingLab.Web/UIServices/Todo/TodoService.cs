using AutoMapper;

using LivingLab.Core.Interfaces.Services;
using LivingLab.Web.Models.DTOs.Todo;

namespace LivingLab.Web.UIServices.Todo;
/// <summary>
/// This is a UI-specific service so it belongs in the Web project.
/// It does not contain any business logic and works with UI-specific types (view models and DTOs).
/// </summary>
public class TodoService : ITodoService
{
    private readonly IMapper _mapper;
    private readonly ITodoDomainService _todoDomainService;
    public TodoService(IMapper mapper, ITodoDomainService todoDomainService)
    {
        _mapper = mapper;
        _todoDomainService = todoDomainService;
    }

    public async Task<List<TodoDTO>> GetAllTodosAsync()
    {
        var todos = await _todoDomainService.GetAllTodosAsync();
        return _mapper.Map<List<Core.Entities.Todo>, List<TodoDTO>>(todos);
    }

    public async Task<TodoDTO> GetTodoAsync(int id)
    {
        var todo = await _todoDomainService.GetTodoAsync(id);
        return _mapper.Map<Core.Entities.Todo, TodoDTO>(todo);
    }

    public async Task<TodoDTO> CreateTodoAsync(CreateTodoDTO todo)
    {
        var newTodo = _mapper.Map<CreateTodoDTO, Core.Entities.Todo>(todo);

        var createdTodo = await _todoDomainService.CreateTodoAsync(newTodo);

        return _mapper.Map<Core.Entities.Todo, TodoDTO>(createdTodo);
    }
}
