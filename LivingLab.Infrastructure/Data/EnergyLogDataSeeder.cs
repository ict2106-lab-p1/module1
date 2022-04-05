using LivingLab.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Data;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public static class EnergyLogDataSeeder
{
    public static void SeedEnergyLogs(this ModelBuilder modelBuilder)
    {
        var logs = new List<EnergyUsageLog>();
        var logId = 1;
        var now = DateTime.Now;
        var random = new Random();

        for (var labId = 1; labId <= 3; labId++)
        {
            var startDate = now.AddDays(-30).Date + new TimeSpan(0, 0, 0);
            var endDate = now.Date + new TimeSpan(23, 59, 59);

            var current = startDate;
            
            while (current < endDate)
            {
                logs.Add(new EnergyUsageLog
                {
                    Id = logId++,
                    DeviceId = 1,
                    LabId = labId,
                    EnergyUsage = GetRandomUsage(random, current),
                    Interval = TimeSpan.FromMinutes(10),
                    LoggedDate = current
                });
                current = current.AddMinutes(10);
            }
        }
        modelBuilder.Entity<EnergyUsageLog>().HasData(logs);
    }

    /// <summary>
    /// Generate a random number.
    ///
    /// 900 to 1000 if peak hour
    /// 600 to 699 if non peak hour
    /// </summary>
    /// <param name="random">random instance</param>
    /// <param name="time">current time</param>
    /// <returns>randomly generated number</returns>
    private static double GetRandomUsage(Random random, DateTime time)
    {
        var min = IsPeak(time.Hour) ? 900 : 600;
        var max = IsPeak(time.Hour) ? 1000 : 699;
        return random.Next(min, max);
    }

    /// <summary>
    /// Check if timing is between 9am to 6pm (working hours).
    ///
    /// 
    /// </summary>
    /// <param name="hour"></param>
    /// <returns>true if between 9am to 6pm, false otherwise</returns>
    private static bool IsPeak(int hour)
    {
        return hour is >= 9 and <= 18;
    }
}
