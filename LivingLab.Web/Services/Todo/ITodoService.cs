using LivingLab.Web.Models.DTOs.Todo;

namespace LivingLab.Web.Services.Todo;
/// <summary>
/// This is the service that handles the todo list.
/// </summary>
public interface ITodoService
{
    Task<List<TodoDTO>> GetAllTodosAsync();
    Task<TodoDTO> GetTodoAsync(int id);
    Task<TodoDTO> CreateTodoAsync(CreateTodoDTO todo);
}
