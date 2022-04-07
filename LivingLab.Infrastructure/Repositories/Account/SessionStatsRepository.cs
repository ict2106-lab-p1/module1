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

    /// <summary>
    /// Gets the list of sessions statistics for the current lab
    /// </summary>
    /// <param name="labLocation"> The Name of the Lab, e.g "NYP-SR7B" </param>
    /// <returns> Iterable list of sessionsStats objects </returns>
    public async Task<List<SessionStats>> GetSessionStatsView(string labLocation)
    {
        List<SessionStats> sessionStats = await _context.SessionStats
            .Include(l => l.Lab)
            .Include(l => l.Lab.ApplicationUser)
            .Where(l => l.Lab!.LabLocation == labLocation)
            .ToListAsync();
        return sessionStats;
    }

    /// <summary>
    /// Logs the size of the file uploaded to for a lab
    /// </summary>
    /// <param name="labId"> Lab ID e.g "1" </param>
    /// <param name="fileSize"> File size in kb </param>
    public async void LogFileUpload(int labId, double fileSize)
    {
        SessionStats device = (await _context.SessionStats.Where(s => s.Id == Convert.ToInt32(labId)).FirstOrDefaultAsync())!;
        if (device.DataUploaded != fileSize)
        {
            device.DataUploaded = fileSize;
        }

        await _context.SaveChangesAsync();
    }

}
