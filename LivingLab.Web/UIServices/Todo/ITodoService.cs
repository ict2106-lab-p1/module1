using LivingLab.Web.Models.DTOs.Todo;

namespace LivingLab.Web.UIServices.Todo;

public interface ITodoService
{
    Task<List<TodoDTO>> GetAllTodosAsync();
    Task<TodoDTO> GetTodoAsync(int id);
    Task<TodoDTO> CreateTodoAsync(CreateTodoDTO todo);
}
