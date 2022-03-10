using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;

public interface ITodoRepository : IRepository<Todo>
{
    Task<string> GetTodoTitle(int id);
}
