using System.Text;

using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageBuilder;
using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageCalculation;
using LivingLab.Core.DomainServices.Equipment;
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
        // missing of lab area, commenting this part to ensure no error


        List<EnergyUsageLog> result = _repository.GetDeviceEnergyUsageByDateTime(start,end).Result;
        List<LabEnergyUsageDTO> LabEUList = new List<LabEnergyUsageDTO>();
        List<string> uniqueLab = new List<string>();
        List<int> LabEUWatt = new List<int>();
        List<double> LabEUCost = new List<double>();
        List<double> LabEUIntensity = new List<double>();
        List<int> LabArea = new List<int>();
        List<EUWatt> EUWatt =  new List<EUWatt>();

        /*
        * get the unique lab into a list
        */
        foreach (var item in result)
        {
            if (!uniqueLab.Contains(item.Lab.LabLocation))
            {
                uniqueLab.Add(item.Lab.LabLocation);
                LabArea.Add(item.Lab.Capacity??0);
                LabEUWatt.Add(0);    
            }
            EUWatt.Add(new EUWatt
            {
                id = item.Lab.LabLocation,
                EU = _calculator.CalculateEnergyUsageInWatt((int) item.EnergyUsage,item.Interval.Minutes)
            });
        }
        Console.WriteLine("first section done");
        /*
        * get the unique lab into a list
        */
        for (int i = 0; i < uniqueLab.Count; i++)
        {
            for (int j = 0; j < EUWatt.Count; j++)
            {
                if (EUWatt[j].id == uniqueLab[i])
                {
                    LabEUWatt[i] += EUWatt[j].EU;
                }
            }
        }
        Console.WriteLine("second section done");
        
        /*
        * get the unique lab into a list
        */
        for (int i = 0; i < uniqueLab.Count; i++)
        {
            LabEUCost.Add(_calculator.CalculateEnergyUsageCost(cost,LabEUWatt[i]));
            LabEUIntensity.Add(_calculator.CalculateEnergyIntensity(LabArea[i],LabEUWatt[i]));
        }

        // append the list of data to DeviceEnergyUsageDTO
        for (int i = 0; i < uniqueLab.Count; i++)
        {
            // 
            // 
            LabEUList.Add(new LabEnergyUsageDTO{
                LabLocation = uniqueLab[i],
                TotalEnergyUsage = Math.Round((double)LabEUIntensity[i]/1000,2),
                EnergyUsageCost = LabEUCost[i],
                EnergyUsageIntensity = Math.Round((double)LabEUWatt[i]/1000,2)
                });

        }
        Console.WriteLine("Third section done");
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
    
    // weijie
    // not sure what will be your DTO looks like may have to create in LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
    public List<DeviceInLabDTO> GetEnergyUsageLabDistribution(DateTime start, DateTime end, int labId)
    {
        throw new NotImplementedException();
    }
    public List<DeviceInLabDTO> GetEnergyUsageDeviceDistribution(DateTime start, DateTime end, string deviceType)
    {
        throw new NotImplementedException();
    }
}

public class EUWatt{
    public string id  {get; set;}
    public int EU {get; set;}
}
