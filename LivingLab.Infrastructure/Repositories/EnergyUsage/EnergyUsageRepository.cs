using LivingLab.Core.Entities;
using LivingLab.Core.Repositories.EnergyUsage;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories.EnergyUsage;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class EnergyUsageRepository : Repository<EnergyUsageLog>, IEnergyUsageRepository
{
    private readonly ApplicationDbContext _context;

    public EnergyUsageRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    /// <summary>
    /// insert an entire collection of logs in a single operation
    /// </summary>
    /// <param name="logs">collection of log entities to insert</param>
    public async Task BulkInsertAsync(ICollection<EnergyUsageLog> logs)
    {
        foreach (var log in logs)
        {
            log.Device = await _context.Devices.FirstOrDefaultAsync(d => d.SerialNo == log.Device.SerialNo);
            log.Lab = await _context.Labs.FirstOrDefaultAsync(l => l.LabLocation == log.Lab.LabLocation);
            await _context.AddAsync(log);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// get logs for energy usage that occurred within a certain period
    /// </summary>
    /// <param name="start">start of selected period</param>
    /// <param name="start">end of selected period</param>
    /// <returns>list of energy usage logs that match the criteria</returns>
    public async Task<List<EnergyUsageLog>> GetDeviceEnergyUsageByDateTime(DateTime start, DateTime end)
    {
        var logsForDateRange = await IncludeReferences(
                _context.EnergyUsageLogs
                .Where(log => log.LoggedDate >= start && log.LoggedDate <= end)
            )
            .ToListAsync();
        return logsForDateRange;
    }

    /// <summary>
    /// get logs for energy usage by devices of a specified type that occurred within a certain period
    /// </summary>
    /// <param name="deviceType">device type/category</param>
    /// <param name="start">start of selected period</param>
    /// <param name="start">end of selected period</param>
    /// <returns>list of energy usage logs that match the criteria</returns>
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

    /// <summary>
    /// get logs for energy usage by devices within a specified lab that occurred within a certain period
    /// </summary>
    /// <param name="labName">name of the lab with devices</param>
    /// <param name="start">start of selected period</param>
    /// <param name="start">end of selected period</param>
    /// <returns>list of energy usage logs that match the criteria</returns>
    public async Task<List<EnergyUsageLog>> GetLabEnergyUsageByLabNameAndDate(string labName, DateTime start, DateTime end)
    {
        var logsForTypeInDateRange = await IncludeReferences(
                _context.EnergyUsageLogs
                .Where(log => log.LoggedDate >= start && log.LoggedDate <= end)
                .Where(log => log.Lab.LabLocation == labName)
            )
            .ToListAsync();
        return logsForTypeInDateRange;
    }

    /// <summary>
    /// get the most recently received n logs
    /// </summary>
    /// <param name="size">number of logs to retrieve</param>
    /// <returns>list of [size] most recent energy usage logs</returns>
    public Task<List<EnergyUsageLog>> GetLatestLogs(int size)
    {
        return _context.EnergyUsageLogs
            .Include(l => l.Lab)
            .Include(l => l.Device)
            .OrderByDescending(l => l.LoggedDate)
            .Take(size)
            .ToListAsync();
    }

    /// <summary>
    /// get logs for energy usage by devices within a specified lab that occurred within a certain period
    /// </summary>
    /// <param name="labName">id of the lab with devices</param>
    /// <param name="start">start of selected period</param>
    /// <param name="start">end of selected period</param>
    /// <returns>list of energy usage logs that match the criteria</returns>
    public async Task<List<EnergyUsageLog>> GetDeviceEnergyUsageByLabAndDate(int labId, DateTime? start, DateTime? end)
    {
        var now = DateTime.Now;

        start ??= now.AddDays(-30).Date;
        end ??= now.Date;

        start += new TimeSpan(0, 0, 0);
        end += new TimeSpan(23, 59, 59);

        var logsForLabInDateRange = await IncludeReferences(
                _context.EnergyUsageLogs
                    .Where(log => log.LoggedDate >= start && log.LoggedDate <= end)
                    .Where(log => log.Lab!.LabId == labId)
            )
            .ToListAsync();
        return logsForLabInDateRange;
    }

    /// <summary>
    /// 1. define the start and end date
    /// 2. get the lab energy usage data according to the lab location, start and end date
    /// </summary>
    /// <param name="labLocation">lab location</param>
    /// <param name="start">start date</param>
    /// <param name="end">end date</param>
    /// <returns>list of EnergyUsageLog</returns>
    public async Task<List<EnergyUsageLog>> GetLabEnergyUsageByLocationAndDate(string labLocation, DateTime? start, DateTime? end)
    {
        var now = DateTime.Now;

        start ??= now.AddDays(-30).Date;
        end ??= now.Date;

        start += new TimeSpan(0, 0, 0);
        end += new TimeSpan(23, 59, 59);

        Console.WriteLine("START: " + start);
        Console.WriteLine("END: " + end);

        var logsForLabInDateRange = await IncludeReferences(
                _context.EnergyUsageLogs
                    .Where(log => log.LoggedDate >= start && log.LoggedDate <= end)
                    .Where(log => log.Lab!.LabLocation == labLocation)
                )
            .ToListAsync();
        return logsForLabInDateRange;
    }

    /// <summary>
    /// 1. define the start and end date
    /// 2. get the lab energy usage data according to the start and end date
    /// </summary>
    /// <param name="start">start date</param>
    /// <param name="end">end date</param>
    /// <returns>list of EnergyUsageLog</returns>
    public async Task<List<EnergyUsageLog>> GetLabEnergyUsageByDate(DateTime? start, DateTime? end)
    {
        var now = DateTime.Now;

        start ??= now.AddDays(-30).Date;
        end ??= now.Date;

        start += new TimeSpan(0, 0, 0);
        end += new TimeSpan(23, 59, 59);

        var logsForLabInDateRange = await IncludeReferences(
                _context.EnergyUsageLogs
                    .Where(log => log.LoggedDate >= start && log.LoggedDate <= end)
            )
            .ToListAsync();
        return logsForLabInDateRange;
    }

    /// <summary>
    /// get logs for energy usage from a specified device
    /// </summary>
    /// <param name="id">id of device</param>
    /// <returns>list of energy usage logs that match the criteria</returns>
    public async Task<List<EnergyUsageLog>> GetUsageByDeviceId(int id)
    {
        var logsForDevice = await IncludeReferences(
                _context.EnergyUsageLogs
                .Where(log => log.Device!.Id == id)
            )
            .ToListAsync();
        return logsForDevice;
    }

    /// <summary>
    /// get logs for energy usage from devices of a specified type
    /// </summary>
    /// <param name="deviceType">device type/category</param>
    /// <returns>list of energy usage logs that match the criteria</returns>
    public async Task<List<EnergyUsageLog>> GetUsageByDeviceType(string deviceType)
    {
        var logsForType = await IncludeReferences(
                _context.EnergyUsageLogs
                .Where(log => log.Device!.Type == deviceType)
            )
            .ToListAsync();
        return logsForType;
    }

    /// <summary>
    /// get logs for energy usage by devices within a specified lab
    /// </summary>
    /// <param name="labName">id of the lab with devices</param>
    /// <returns>list of energy usage logs that match the criteria</returns>
    public async Task<List<EnergyUsageLog>> GetUsageByLabId(int id)
    {
        var logsForLab = await IncludeReferences(
                _context.EnergyUsageLogs
                .Where(log => log.Lab!.LabId == id)
            )
            .ToListAsync();
        return logsForLab;
    }

    /// <summary>
    /// override base repository class method to load associated labs and devices
    /// </summary>
    /// <param name="logQuery"></param>
    /// <returns></returns>
    protected override IQueryable<EnergyUsageLog> IncludeReferences(IQueryable<EnergyUsageLog> logQuery)
    {
        return base.IncludeReferences(logQuery)
            .Include(log => log.Device)
            .Include(log => log.Lab);
    }

    /// <summary>
    /// override base repository class method to load associated labs and devices
    /// </summary>
    /// <param name="log"></param>
    protected override async Task IncludeReferencesForFindAsync(EnergyUsageLog log)
    {
        await base.IncludeReferencesForFindAsync(log);
        var deviceLoadTask = _context.Entry(log).Reference(l => l.Device).LoadAsync();
        var labLoadTask = _context.Entry(log).Reference(l => l.Lab).LoadAsync();
        await Task.WhenAll(deviceLoadTask, labLoadTask);
    }
}
