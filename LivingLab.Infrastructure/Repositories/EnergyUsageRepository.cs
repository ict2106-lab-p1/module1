using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageRepository : Repository<EnergyUsageLog>, IEnergyUsageRepository
{
    private readonly ApplicationDbContext _context;

    public EnergyUsageRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task BulkInsertAsync(ICollection<EnergyUsageLog> logs)
    {
        foreach (var log in logs)
        {
            // TODO: Change to repo method
            log.Device = await _context.Devices.FirstOrDefaultAsync(d => d.SerialNo == log.Device.SerialNo);
            log.Lab = await _context.Labs.FirstOrDefaultAsync(l => l.LabId == 1);
            await _context.AddAsync(log);
        }

        await _context.SaveChangesAsync();
    }

    public async Task BulkInsertAsyncByUser(ICollection<EnergyUsageLog> logs, ApplicationUser loggedBy)
    {
        logs.ToList().ForEach(log => log.LoggedBy = loggedBy);
        await BulkInsertAsync(logs);
    }

    public async Task<List<EnergyUsageLog>> GetDeviceEnergyUsageByDateTime(DateTime start, DateTime end)
    {
        var logsForDateRange = await IncludeReferences(
                _context.EnergyUsageLogs
                .Where(log => log.LoggedDate >= start && log.LoggedDate <= end)
            )
            .ToListAsync();
        return logsForDateRange;
    }

    public async Task<List<EnergyUsageLog>> GetDeviceEnergyUsageByDeviceTypeAndDate(string deviceType, DateTime start, DateTime end)
    {
        var logsForTypeInDateRange = await IncludeReferences(
                _context.EnergyUsageLogs
                .Where(log => log.LoggedDate >= start && log.LoggedDate <= end)
                .Where(log => log.Device!.Type == deviceType)
            )
            .ToListAsync();
        return logsForTypeInDateRange;
    }

    public Task<List<EnergyUsageLog>> GetDistinctDeviceEnergyUsage()
    {
        throw new NotImplementedException();
    }

    public Task<List<EnergyUsageLog>> GetDistinctLabEnergyUsage()
    {
        throw new NotImplementedException();
    }

    public Task<List<EnergyUsageLog>> GetAllDeviceByLab()
    {
        throw new NotImplementedException();
    }

    public async Task<List<EnergyUsageLog>> GetUsageByDeviceId(int id)
    {
        var logsForDevice = await IncludeReferences(
                _context.EnergyUsageLogs
                .Where(log => log.Device!.Id == id)
            )
            .ToListAsync();
        return logsForDevice;
    }

    public async Task<List<EnergyUsageLog>> GetUsageByDeviceType(string deviceType)
    {
        var logsForType = await IncludeReferences(
                _context.EnergyUsageLogs
                .Where(log => log.Device!.Type == deviceType)
            )
            .ToListAsync();
        return logsForType;
    }

    public async Task<List<EnergyUsageLog>> GetUsageByLabId(int id)
    {
        var logsForLab = await IncludeReferences(
                _context.EnergyUsageLogs
                .Where(log => log.Lab!.LabId == id)
            )
            .ToListAsync();
        return logsForLab;
    }

    public Task<List<EnergyUsageLog>> GetUsageByUser(ApplicationUser? user)
    {
        if (user == null)
        {
            return IncludeReferences(
                    _context.EnergyUsageLogs
                    .Where(log => log.LoggedBy != null)
                )
                .ToListAsync();
        }
        else
        {
            return IncludeReferences(
                    _context.EnergyUsageLogs
                    .Where(log => log.LoggedBy != null && log.LoggedBy.Equals(user))
                )
                .ToListAsync();
        }
    }
    protected override IQueryable<EnergyUsageLog> IncludeReferences(IQueryable<EnergyUsageLog> logQuery)
    {
        return base.IncludeReferences(logQuery)
            .Include(log => log.Device)
            .Include(log => log.Lab);
    }

    protected override async Task IncludeReferencesForFindAsync(EnergyUsageLog log)
    {
        await base.IncludeReferencesForFindAsync(log);
        var deviceLoadTask = _context.Entry(log).Reference(l => l.Device).LoadAsync();
        var labLoadTask = _context.Entry(log).Reference(l => l.Lab).LoadAsync();
        await Task.WhenAll(deviceLoadTask, labLoadTask);
    }
}
