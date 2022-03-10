using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

public class LabRepository : Repository<Lab>, ILabRepository
{
    private readonly ApplicationDbContext _context;

    public LabRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    //public async Task<string?> GetTodoTitle(int id)
    //{
    //    var todo = await _context.Todos.FirstOrDefaultAsync(t => t.ID == id);
    //    return todo?.Title;
    //}

}
