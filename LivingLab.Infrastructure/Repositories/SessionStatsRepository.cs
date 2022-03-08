using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

public class SessionStatsRepository : Repository<SessionStats>, ISessionStatsRepository
{
    private readonly ApplicationDbContext _context;

    public SessionStatsRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    //public async Task<string?> GetTodoTitle(int id)
    //{
    //    var todo = await _context.Todos.FirstOrDefaultAsync(t => t.ID == id);
    //    return todo?.Title;
    //}

}
