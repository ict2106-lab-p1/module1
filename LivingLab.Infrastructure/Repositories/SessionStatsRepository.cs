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

    public async Task<List<SessionStats>> GetSessionStatsView()
    {
        List<SessionStats> sessionStats = await _context.SessionStats.ToListAsync();
        return sessionStats;
    }
}
