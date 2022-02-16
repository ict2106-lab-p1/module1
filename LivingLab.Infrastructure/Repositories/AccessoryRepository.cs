using LivingLab.Domain.Entities;
using LivingLab.Domain.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

public class AccessoryRepository : Repository<Accessory>, IAccessoryRepository
{
    private readonly ApplicationDbContext _context;

    public AccessoryRepository (ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    //public async Task<string?> GetTodoTitle(int id)
    //{
    //    var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
    //    return todo?.Title;
    //}

}
