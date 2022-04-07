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
    /// <summary>
    /// save file temporarily on disk
    /// </summary>
    /// <param name="file">CSV file</param>
    /// <returns>path to temporary location allocated by system</returns>
    protected override string SaveFile(IFormFile file)
    {
        var filePath = Path.GetTempFileName();
        using var stream = new FileStream(filePath, FileMode.Create);
        file.CopyTo(stream);
        return filePath;
    }

    /// <summary>
    /// read CSV file from disk and interpret as iterable objects
    /// </summary>
    /// <param name="filePath">path to CSV file on disk</param>
    /// <returns>on-demand query that generates objects</returns>
    protected override ParallelQuery<CsvMappingResult<EnergyUsageCsvDTO>> ReadFile(string filePath)
    {
        var options = new CsvParserOptions(true, ',');
        var mapper = new EnergyUsageLogCsvMapper();
        var parser = new CsvParser<EnergyUsageCsvDTO>(options, mapper);
        var result = parser.ReadFromFile(filePath, Encoding.Default);
        return result;
    }

    /// <summary>
    /// map all given CSV row objects to EnergyUsageCsvDTO objects
    /// </summary>
    /// <param name="result">query that generates CSV row objects</param>
    /// <returns>iterable of EnergyUsageCsvDTO objects</returns>
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
