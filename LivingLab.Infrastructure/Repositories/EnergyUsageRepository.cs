using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

public class EnergyUsageRepository : Repository<EnergyUsageLog>, IEnergyUsageRepository
{
    private readonly ApplicationDbContext _context;

    public EnergyUsageRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task BulkInsertAsync(ICollection<EnergyUsageLog> logs)
    {
        await _context.AddAsync(logs);
        await _context.SaveChangesAsync();
    }

    public async Task<List<EnergyUsageLog>> GetUsageByDeviceId(int id)
    {
        var logsForDevice = await _context.EnergyUsageLogs
            .Where(log => log.Device!.Id == id)
            .ToListAsync();
        return logsForDevice;
    }

    public async Task<List<EnergyUsageLog>> GetUsageByDeviceType(string deviceType)
    {
        var logsForType = await _context.EnergyUsageLogs
            .Where(log => log.Device!.Type == deviceType)
            .ToListAsync();
        return logsForType;
    }

    public async Task<List<EnergyUsageLog>> GetUsageByLabId(int id)
    {
        var logsForLab = await _context.EnergyUsageLogs
            .Where(log => log.Lab!.Id == id)
            .ToListAsync();
        return logsForLab;
    }
}
