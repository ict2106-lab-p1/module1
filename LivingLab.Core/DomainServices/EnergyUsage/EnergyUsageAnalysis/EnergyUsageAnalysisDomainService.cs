using System.Text;

using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageBuilder;
using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageCalculation;
using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageTemplate;
using LivingLab.Core.DomainServices.Equipment.Device;
using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsage;
using LivingLab.Core.Repositories.EnergyUsage;
using LivingLab.Core.Repositories.Lab;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageAnalysis;

/// <remarks>
///     Author: Team P1-2
/// </remarks>
public class EnergyUsageAnalysisDomainDomainService : IEnergyUsageAnalysisDomainService
{
    private readonly IEnergyUsageRepository _repository;
    private readonly ILabProfileRepository _labRepository;
    private const int OneThousand = 1000;

    private readonly IEnergyUsageCalculationService _calculator = new EnergyUsageCalculationService();

    private double cost = 0.2544;

    public EnergyUsageAnalysisDomainDomainService(IEnergyUsageRepository repository, ILabProfileRepository labRepository)
    {
        _repository = repository;
        _labRepository = labRepository;
    }

    /// <summary>
    ///     1. get the colname
    ///     2. store the col name and data in byte format
    /// </summary>
    /// <param name="DeviceEUList">List of data to be export</param>
    /// <returns>byte string of the data</returns>
    public byte[] ExportDeviceEU(List<DeviceEnergyUsageDTO> DeviceEUList)
    {
        var builder = new StringBuilder();
        var ColNames = "";
        foreach (var propertyInfo in typeof(DeviceEnergyUsageDTO).GetProperties())
        {
            ColNames = ColNames + propertyInfo.Name + ",";
        }

        builder.AppendLine(ColNames);
        foreach (var item in DeviceEUList)
        {
            builder.AppendLine(
                $"{item.DeviceSerialNo},{item.DeviceType},{item.TotalEnergyUsage},{item.EnergyUsageCost}");
        }

        return Encoding.UTF8.GetBytes(builder.ToString());
    }

    /// <summary>
    ///     1. retrieve device energy usage log according to data
    /// </summary>
    /// <param name="start">start date</param>
    /// <param name="end">end date</param>
    /// <returns>list of DeviceEnergyUsageDTO</returns>
    public List<DeviceEnergyUsageDTO> GetDeviceEnergyUsageByDate(DateTime start, DateTime end)
    {
        var result = _repository.GetDeviceEnergyUsageByDateTime(start, end).Result;

        //builder
        var director = new DeviceDirector();
        var builder = new DeviceEnergyUsageBuilder(result);
        director.Builder = builder;
        director.BuildDeviceEU();
        return builder.GetProduct();
    }

    /// <summary>
    ///     1. retrieve lab energy usage log according to data
    /// </summary>
    /// <param name="start">start date</param>
    /// <param name="end">end date</param>
    /// <returns>list of LabEnergyUsageDTO</returns>
    public List<LabEnergyUsageDTO> GetLabEnergyUsageByDate(DateTime start, DateTime end)
    {
        var result = _repository.GetDeviceEnergyUsageByDateTime(start, end).Result;
        var labEUCon = new LabEnergyUsageConstructor();
        var LabEUList = labEUCon.MergeIntoCollection(result);
        return LabEUList;
    }

    /// <summary>
    ///     1. get the lab energy usage according to start and end date
    ///     2. get lab repository by lab Id
    ///     3. init MonthlyEnergyUsageDTO
    /// </summary>
    /// <param name="filter">filter start and end date</param>
    /// <returns>MonthlyEnergyUsageDTO</returns>
    public async Task<MonthlyEnergyUsageDTO> GetEnergyUsageTrendAllLab(EnergyUsageFilterDTO filter)
    {
        // Grouping done here because SQLite doesn't support it
        var logs = _repository
            .GetLabEnergyUsageByDate(filter.Start, filter.End)
            .Result
            .GroupBy(log => log.LoggedDate.Date)
            .Select(log => new EnergyUsageLog
            {
                LoggedDate = log.Key,
                EnergyUsage = log.Sum(l => l.EnergyUsage) / OneThousand,
                Device = log.First().Device,
                Lab = log.First().Lab
            })
            .OrderBy(log => log.LoggedDate).ToList();

        var lab = await _labRepository.GetByIdAsync(filter.LabId);
        var dto = new MonthlyEnergyUsageDTO { Logs = logs, Lab = lab };
        return dto;
    }

    /// <summary>
    ///     1. get the lab energy benchmark using lab Id
    /// </summary>
    /// <param name="labid">lab id</param>
    /// <returns>Lab Id from Lab entity</returns>
    public Task<Entities.Lab> GetLabEnergyBenchmark(int labId)
    {
        return _labRepository.GetByIdAsync(labId);
    }

    /// <summary>
    ///     1. get the selected lab energy usage according to lab location, start and end date
    ///     2. get lab repository by lab location
    ///     3. init MonthlyEnergyUsageDTO
    /// </summary>
    /// <param name="filter">filter start and end date</param>
    /// <returns>IndividualLabMonthlyEnergyUsageDTO</returns>
    public async Task<IndividualLabMonthlyEnergyUsageDTO> GetEnergyUsageTrendSelectedLab(
        [FromBody] EnergyUsageFilterDTO filter)
    {
        // Grouping done here because SQLite doesn't support it
        var logs = (await _repository
                .GetLabEnergyUsageByLocationAndDate(filter.LabLocation, filter.Start, filter.End))
            .GroupBy(log => log.LoggedDate.Date)
            .Select(log => new EnergyUsageLog
            {
                LoggedDate = log.Key,
                EnergyUsage = log.Sum(l => l.EnergyUsage) / OneThousand,
                Device = log.First().Device,
                Lab = log.First().Lab
            })
            .OrderBy(log => log.LoggedDate).ToList();

        var lab = await _labRepository.GetByIdAsync(filter.LabId);
        var dto = new IndividualLabMonthlyEnergyUsageDTO { Logs = logs, Lab = lab };
        return dto;
    }
}

/// <summary>
///     data class store energy usage in watt
/// </summary>
public class EUWatt
{
    public string? id { get; set; }
    public int EU { get; set; }
}
