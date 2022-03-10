using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;

namespace LivingLab.Core.DomainServices;

public class TodoDomainService : ITodoDomainService
{
    private readonly ITodoRepository _todoRepository;
    
    public TodoDomainService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }
    
    public async Task<List<Todo>> GetAllTodosAsync()
    {
        return await _todoRepository.GetAllAsync();
    }

    public async Task<Todo> GetTodoAsync(int id)
    {
        return await _todoRepository.GetByIdAsync(id);
    }

    public async Task<Todo> CreateTodoAsync(Todo todo)
    {
        return await _todoRepository.AddAsync(todo);
    }
}
