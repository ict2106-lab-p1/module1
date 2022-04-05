using LivingLab.Core.Entities;
using LivingLab.Core.Repositories.Account;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories.Account;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class SessionStatsRepository : Repository<SessionStats>, ISessionStatsRepository
{
    private readonly ApplicationDbContext _context;

    public SessionStatsRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<SessionStats>> GetSessionStatsView(string labLocation)
    {
        List<SessionStats> sessionStats = await _context.SessionStats
            .Include(l => l.Lab)
            .Include(l => l.Lab.ApplicationUser)
            .Where(l => l.Lab!.LabLocation == labLocation)
            .ToListAsync();
        return sessionStats;
    }
    
    public async void LogFileUpload(string labId, double fileSize)
    {
        SessionStats device = (await _context.SessionStats.Where(s => s.Id == Convert.ToInt32(labId)).FirstOrDefaultAsync())!;
        if (device.DataUploaded != fileSize)
        {
            device.DataUploaded = fileSize;
        }
        
        await _context.SaveChangesAsync();
    }
    
}
