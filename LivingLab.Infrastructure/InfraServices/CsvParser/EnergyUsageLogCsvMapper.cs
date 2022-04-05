using LivingLab.Core.Entities.DTO.EnergyUsage;

using TinyCsvParser.Mapping;

namespace LivingLab.Infrastructure.InfraServices.CsvParser;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageLogCsvMapper : CsvMapping<EnergyUsageCsvDTO>
{
    public EnergyUsageLogCsvMapper()
    {
        MapProperty(0, x => x.LabLocation);
        MapProperty(1, x => x.DeviceType);
        MapProperty(2, x => x.DeviceSerialNo);
        MapProperty(3, x => x.EnergyUsage);
        MapProperty(4, x => x.Interval);
        MapProperty(5, x => x.LoggedDate);
    }
}
