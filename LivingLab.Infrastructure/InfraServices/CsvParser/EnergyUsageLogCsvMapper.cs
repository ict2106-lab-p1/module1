using LivingLab.Core.Models;

using TinyCsvParser.Mapping;

namespace LivingLab.Infrastructure.InfraServices.CsvParser;

public class EnergyUsageLogCsvMapper : CsvMapping<EnergyUsageCsvModel>
{
    public EnergyUsageLogCsvMapper()
    {
        MapProperty(0, x => x.DeviceSerialNo);
        MapProperty(1, x => x.EnergyUsage);
        MapProperty(2, x => x.Interval);
        MapProperty(3, x => x.LoggedDate);
    }
}
