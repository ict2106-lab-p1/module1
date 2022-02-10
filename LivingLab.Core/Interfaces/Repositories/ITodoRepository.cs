using LivingLab.Domain.Entities;

namespace LivingLab.Domain.Interfaces.Repositories;

public interface ITodoRepository : IRepository<Todo>
{
    Task<string> GetTodoTitle(int id);
}
