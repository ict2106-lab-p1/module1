using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Services;

public interface ITodoDomainService
{
    Task<List<Todo>> GetAllTodosAsync();
    Task<Todo> GetTodoAsync(int id);
    Task<Todo> CreateTodoAsync(Todo todo);
}
