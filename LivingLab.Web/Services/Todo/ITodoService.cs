using LivingLab.Web.Models.DTOs.Todo;

namespace LivingLab.Web.Services.Todo;

public interface ITodoService
{
    Task<List<TodoDTO>> GetAllTodosAsync();
    Task<TodoDTO> GetTodoAsync(int id);
    Task<TodoDTO> CreateTodoAsync(CreateTodoDTO todo);
}
