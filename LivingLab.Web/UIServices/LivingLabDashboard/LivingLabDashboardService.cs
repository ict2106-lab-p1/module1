using LivingLab.Web.UIServices.EnergyLog;

namespace LivingLab.Web.UIServices.LivingLabDashboard;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LivingLabDashboardService : ILivingLabDashboardService
{

    private readonly IEnergyLogService _energyLogService;

    public LivingLabDashboardService(IEnergyLogService energyLogService)
    {
        _energyLogService = energyLogService;
    }

    /// <summary>
    /// Get energy usage (yesterday, last week, last month)
    /// </summary>
    /// <returns>usages</returns>
    public async Task<List<string>> GetUsages()
    {
        var usages = new List<string>();

        DateTime previousMonth = DateTime.Now.AddDays(-30);
        DateTime previousWeek = DateTime.Now.AddDays(-7);
        DateTime previousDay = DateTime.Now.AddDays(-1);

        var EnergyResult = await _energyLogService.GetLogs(1000);

        Double totalUsageMonth = 0.0;
        Double totalUsageWeek = 0.0;
        Double totalUsageDay = 0.0;

        foreach (var data in EnergyResult)
        {
            if (data.LoggedDate > previousMonth)
            {
                totalUsageMonth += data.EnergyUsage;
            }
            if (data.LoggedDate > previousWeek)
            {
                totalUsageWeek += data.EnergyUsage;
            }
            if (data.LoggedDate > previousDay)
            {
                totalUsageDay += data.EnergyUsage;
            }
        }

        usages.Add(String.Format("{0:0.00}", totalUsageMonth / 1000));
        usages.Add(String.Format("{0:0.00}", (totalUsageWeek / 1000) / 4));
        usages.Add(String.Format("{0:0.00}", totalUsageDay / 1000));
        return usages;
    }
}
