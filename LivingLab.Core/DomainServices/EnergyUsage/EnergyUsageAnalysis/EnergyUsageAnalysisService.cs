using System.Text;

using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageBuilder;
using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageCalculation;
using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageTemplate;
using LivingLab.Core.DomainServices.Equipment;
using LivingLab.Core.DomainServices.Equipment.Device;
using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsage;
using LivingLab.Core.Repositories.EnergyUsage;
using LivingLab.Core.Repositories.Lab;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageAnalysis;
/// <remarks>
/// Author: Team P1-2
/// </remarks>

public class EnergyUsageAnalysisService : IEnergyUsageAnalysisService
{
    private readonly IEnergyUsageRepository _repository;
    private readonly ILabProfileRepository _labRepository;
    
    private readonly IEnergyUsageCalculationService _calculator = new EnergyUsageCalculationService();

    private double cost = 0.2544;

    public EnergyUsageAnalysisService(IEnergyUsageRepository repository, ILabProfileRepository labRepository)
    {
        _repository = repository;
        _labRepository = labRepository;
    }

    public byte[] ExportDeviceEU(List<DeviceEnergyUsageDTO> DeviceEUList) 
    {
        var builder = new StringBuilder();
        var ColNames = "";
        foreach(var propertyInfo in typeof(DeviceEnergyUsageDTO).GetProperties())
        {
            ColNames = ColNames + propertyInfo.Name + ",";
        }
        builder.AppendLine(ColNames);
        foreach (var item in DeviceEUList)
        {
            builder.AppendLine($"{item.DeviceSerialNo},{item.DeviceType},{item.TotalEnergyUsage},{item.EnergyUsageCost}");
        }
        return Encoding.UTF8.GetBytes(builder.ToString());
    }
    public List<DeviceEnergyUsageDTO> GetDeviceEnergyUsageByDate(DateTime start, DateTime end) 
    {
        List<EnergyUsageLog> result = _repository.GetDeviceEnergyUsageByDateTime(start,end).Result;

        //builder
        DeviceDirector director = new DeviceDirector();
        var builder = new DeviceEnergyUsageBuilder(result);
        director.Builder = builder;
        director.BuildDeviceEU();
        return builder.GetProduct();

    }
    public List<LabEnergyUsageDTO> GetLabEnergyUsageByDate(DateTime start, DateTime end) 
    {
        List<EnergyUsageLog> result = _repository.GetDeviceEnergyUsageByDateTime(start,end).Result;
        LabEnergyUsageConstructor labEUCon = new LabEnergyUsageConstructor();
        var LabEUList = labEUCon.MergeIntoCollection(result);
        return LabEUList;
    }
    // joey
    public List<TopSevenLabEnergyUsageDTO> GetTopSevenLabEnergyUsage(DateTime start, DateTime end) 
    {
        throw new NotImplementedException();
    }
               
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
                EnergyUsage = log.Sum(l => l.EnergyUsage),
                Device = log.First().Device,
                Lab = log.First().Lab
            })
            .OrderBy(log => log.LoggedDate).ToList();

        // get by date
        var lab = await _labRepository.GetByIdAsync(filter.LabId);
        
        var dto = new MonthlyEnergyUsageDTO
        {
            Logs = logs,
            Lab = lab
        };
        return dto;
    }

    public Task<Entities.Lab> GetLabEnergyBenchmark(int labId)
    {
        // add benchmark calculation
        return _labRepository.GetByIdAsync(labId);
    }

    public async Task<IndividualLabMonthlyEnergyUsageDTO> GetEnergyUsageTrendSelectedLab([FromBody] EnergyUsageFilterDTO filter)
    {
        // Grouping done here because SQLite doesn't support it
        var logs = (await _repository
            .GetLabEnergyUsageByLocationAndDate(filter.LabLocation, filter.Start, filter.End))
            .GroupBy(log => log.LoggedDate.Date)
            .Select(log => new EnergyUsageLog
            {
                LoggedDate = log.Key,
                EnergyUsage = log.Sum(l => l.EnergyUsage),
                Device = log.First().Device,
                Lab = log.First().Lab
            })
            .OrderBy(log => log.LoggedDate).ToList();

        var lab = await _labRepository.GetByIdAsync(filter.LabId);

        var dto = new IndividualLabMonthlyEnergyUsageDTO
        {
            Logs = logs,
            Lab = lab
        };
        return dto;
    }
    
}

public class EUWatt{
    public string id  {get; set;}
    public int EU {get; set;}
}
