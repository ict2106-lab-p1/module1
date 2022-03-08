using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

public class AccessoryRepository : Repository<Accessory>, IAccessoryRepository
{
    private readonly ApplicationDbContext _context;

    public AccessoryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Accessory>> GetAccessoryWithAccessoryType()
    {
        // retrieve accessory table together with accessory type details using include to join entities 
        List <Accessory> accessories = await _context.Accessory.Include(a => a.AccessoryType).ToListAsync();
        return accessories;
    }
   

    //public async Task<string?> GetTodoTitle(int id)
    //{
    //    var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
    //    return todo?.Title;
    //}

}
