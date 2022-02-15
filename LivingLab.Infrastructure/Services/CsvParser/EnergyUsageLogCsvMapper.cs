using LivingLab.Core.Models;

using TinyCsvParser.Mapping;

namespace LivingLab.Infrastructure.Services.CsvParser;

public class EnergyUsageLogCsvMapper : CsvMapping<EnergyUsageCsvModel>
{
    public EnergyUsageLogCsvMapper()
    {
        MapProperty(0, x => x.DeviceId);
        MapProperty(1, x => x.DeviceSerialNo);
        MapProperty(2, x => x.EnergyUsage);
        MapProperty(3, x => x.Duration);
        MapProperty(4, x => x.LoggedDate);
    }
}
