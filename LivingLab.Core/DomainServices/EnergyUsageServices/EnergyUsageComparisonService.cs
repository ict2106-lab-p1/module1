using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using System;

namespace LivingLab.Core.DomainServices.EnergyUsageServices;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class EnergyUsageComparisonService : IEnergyUsageComparisonService
{
    //hy, not sure what is your DTO, the DTO have to create in LivingLab.Core.Entities.DTO.EnergyUsageDTOs
    private readonly IEnergyUsageRepository _repository;

    private readonly IDeviceRepository _deviceRepository;

    private readonly ILabRepository _abRepository;

    private readonly IEnergyUsageCalculationService _calculator = new EnergyUsageCalculationService();

    private double cost = 0.2544;

    public EnergyUsageComparisonService(IEnergyUsageRepository repository, IDeviceRepository deviceRepository, ILabRepository labRepository)
    {
        _repository = repository;
        _deviceRepository = deviceRepository;
        _abRepository = labRepository;
    }

    public List<EnergyComparisonLabTableDTO> GetEnergyUsageByLabNameTable(string labName, DateTime start, DateTime end)
    {
        List<EnergyUsageLog> result = _repository.GetLabEnergyUsageByLabNameAndDate(labName, start, end).Result;
        int LabEU = 0;
        double LabEUCost = 0;
        double energyIntensity = 0;
        int LabArea = 0;


        List<EnergyComparisonLabTableDTO> LabEUList = new List<EnergyComparisonLabTableDTO>();


        foreach (var item in result)
        {
            LabEU += _calculator.CalculateEnergyUsageInWatt((int)item.EnergyUsage, item.Interval.Minutes);
            LabArea = item.Lab.Area??0;
        }

        LabEUCost = _calculator.CalculateEnergyUsageCost(cost, LabEU);
        energyIntensity = _calculator.CalculateEnergyIntensity(LabArea, LabEU);


        LabEUList.Add(new EnergyComparisonLabTableDTO
        {
            LabLocation = labName,
            TotalEnergyUsage = Math.Round((double)LabEU / 1000, 2),
            EnergyUsageCost = Math.Round((double)LabEUCost / 1000, 2),
            EnergyUsageIntensity = Math.Round((double)energyIntensity / 1000, 2)
        });

        return LabEUList;
    }

    public List<EnergyComparisonGraphDTO> GetEnergyUsageByLabNameGraph(string labName, DateTime start, DateTime end)
    {
        List<EnergyUsageLog> result = _repository.GetLabEnergyUsageByLabNameAndDate(labName, start, end).Result;
        int LabEU = 0;
        double energyIntensity = 0;
        int LabArea = 0;

        List<EnergyComparisonGraphDTO> LabEUList = new List<EnergyComparisonGraphDTO>();
        //List<EUWatt> EUWatt = new List<EUWatt>();

        foreach (var item in result)
        {
            LabEU += _calculator.CalculateEnergyUsageInWatt((int)item.EnergyUsage, item.Interval.Minutes);
            LabArea = item.Lab.Area ?? 0;
        }

        energyIntensity = _calculator.CalculateEnergyIntensity(LabArea, LabEU);

        LabEUList.Add(new EnergyComparisonGraphDTO
        {
            LabLocation = labName,
            TotalEnergyUsage = Math.Round((double)LabEU / 1000, 2),
            EnergyUsageIntensity = Math.Round((double)energyIntensity / 1000, 2)
        });

        return LabEUList;
    }

    public double GetEnergyUsageByLabNameBenchmark(string[] labNames, DateTime start, DateTime end)
    {
        double benchmark = 0;
        foreach(var i in labNames)
        {
            List<EnergyUsageLog> result = _repository.GetLabEnergyUsageByLabNameAndDate(i, start, end).Result;
            //List<EUWatt> EUWatt = new List<EUWatt>();

            int LabEU = 0;

            foreach (var item in result)
            {
                LabEU += _calculator.CalculateEnergyUsageInWatt((int)item.EnergyUsage, item.Interval.Minutes);
            }

            benchmark += Math.Round((double)LabEU / 1000, 2);

        }

        benchmark = benchmark / labNames.Length;
        return benchmark;
    }

    public List<EnergyComparisonDeviceTableDTO> GetEnergyUsageByDeviceType(string deviceType, DateTime start, DateTime end)
    {
        List<EnergyUsageLog> result = _repository.GetDeviceEnergyUsageByDeviceTypeAndDate(deviceType,start, end).Result;
        int DeviceEU = 0;
        double DeviceEUCost = 0;


        List<EnergyComparisonDeviceTableDTO> DeviceEUList = new List<EnergyComparisonDeviceTableDTO>();
        //List<EUWatt> EUWatt = new List<EUWatt>();

        foreach (var item in result)
        {
            DeviceEU +=  _calculator.CalculateEnergyUsageInWatt((int)item.EnergyUsage, item.Interval.Minutes);
        }

        DeviceEUCost = _calculator.CalculateEnergyUsageCost(cost, DeviceEU);

        //append to list
        DeviceEUList.Add(new EnergyComparisonDeviceTableDTO
        {
            DeviceType = deviceType,
            TotalEnergyUsage = Math.Round((double)DeviceEU / 1000, 2),
            EnergyUsageCost = Math.Round((double)DeviceEUCost / 1000, 2)
        }) ;
        Console.WriteLine(DeviceEUList[0].TotalEnergyUsage);

        return DeviceEUList;
    }

    public List<LabEnergyUsageDTO> GetEnergyUsageEnergyIntensitySelectedLab (int labId, DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }

    public List<string> GetAllDeviceType()
    {
        List<Device> result = _deviceRepository.GetAllDeviceType().Result;
        List<string> deviceType = new List<string>();

        foreach (var item in result)
        {
            deviceType.Add(item.Type);
        }

        return deviceType;

    }
    public List<string> GetAllLabLocation()
    {
        List<Lab> result = _abRepository.GetAllLabLocation().Result;
        List<string> labNames = new List<string>();

        foreach (var item in result)
        {
            labNames.Add(item.LabLocation);
        }

        return labNames;
    }
}