using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;

using TinyCsvParser.Mapping;

namespace LivingLab.Infrastructure.InfraServices.CsvParser;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageLogCsvMapper : CsvMapping<EnergyUsageCsvDTO>
{
    public EnergyUsageLogCsvMapper()
    {
        MapProperty(0, x => x.DeviceType);
        MapProperty(1, x => x.DeviceSerialNo);
        MapProperty(2, x => x.EnergyUsage);
        MapProperty(3, x => x.Interval);
        MapProperty(4, x => x.LoggedDate);
    }
}
