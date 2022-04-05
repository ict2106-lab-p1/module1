using System.Text;

using LivingLab.Core.CsvParser;
using LivingLab.Core.Entities.DTO.EnergyUsage;

using Microsoft.AspNetCore.Http;

using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace LivingLab.Infrastructure.InfraServices.CsvParser;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageLogCsvParser : CsvParserTemplate<EnergyUsageCsvDTO>, IEnergyUsageLogCsvParser
{
    /**
     * Create a temporary random file.
     */
    protected override string SaveFile(IFormFile file)
    {
        var filePath = Path.GetTempFileName();
        using var stream = new FileStream(filePath, FileMode.Create);
        file.CopyTo(stream);
        return filePath;
    }

    protected override ParallelQuery<CsvMappingResult<EnergyUsageCsvDTO>> ReadFile(string filePath)
    {
        var options = new CsvParserOptions(true, ',');
        var mapper = new EnergyUsageLogCsvMapper();
        var parser = new CsvParser<EnergyUsageCsvDTO>(options, mapper);
        var result = parser.ReadFromFile(filePath, Encoding.Default);
        return result;
    }
    
    /**
     * Map processes data to Model.
     */
    protected override IEnumerable<EnergyUsageCsvDTO> MapResult(ParallelQuery<CsvMappingResult<EnergyUsageCsvDTO>> result)
    {
        var list = new List<EnergyUsageCsvDTO>();

        foreach (var item in result)
        {
            list.Add(new EnergyUsageCsvDTO
            {
                LabLocation = item.Result.LabLocation,
                DeviceType = item.Result.DeviceType,
                DeviceSerialNo = item.Result.DeviceSerialNo,
                Interval = item.Result.Interval,
                EnergyUsage = item.Result.EnergyUsage,
                LoggedDate = item.Result.LoggedDate
            });
        }

        return list;
    }
}
