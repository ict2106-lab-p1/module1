using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageCalculation;
using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageTemplate;
using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsage;
using LivingLab.Core.Repositories.EnergyUsage;
using LivingLab.Core.Repositories.Equipment;
using LivingLab.Core.Repositories.Lab;

namespace LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageComparison;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class EnergyUsageComparisonService : IEnergyUsageComparisonService
{
    private readonly IEnergyUsageRepository _repository;

    private readonly IDeviceRepository _deviceRepository;

    private readonly ILabProfileRepository _abRepository;

    private readonly IEnergyUsageCalculationService _calculator = new EnergyUsageCalculationService();

    private double cost = 0.2544;

    public EnergyUsageComparisonService(IEnergyUsageRepository repository, IDeviceRepository deviceRepository, ILabProfileRepository labRepository)
    {
        _repository = repository;
        _deviceRepository = deviceRepository;
        _abRepository = labRepository;
    }

    /// <summary>
    /// Retrieve lab energy usage according to the labName, start and end date
    /// </summary>
    /// <param>lab names</param>
    /// <param>start date</param>
    /// <param>end date</param>
    /// <returns>list of EnergyComparisonLabTableDTO</returns>
    public List<EnergyComparisonLabTableDTO> GetEnergyUsageByLabNameTable(string labName, DateTime start, DateTime end)
    {
        TopLabEnergyUsageConstructor labEUCon = new TopLabEnergyUsageConstructor();
        List<EnergyUsageLog> result = _repository.GetLabEnergyUsageByLabNameAndDate(labName, start, end).Result;
        int LabEU = 0;
        double LabEUCost = 0;
        double energyIntensity = 0;
        int LabArea = 0;


        List<EnergyComparisonLabTableDTO> LabEUList = new List<EnergyComparisonLabTableDTO>();


        foreach (var item in result)
        {
            LabEU += _calculator.CalculateEnergyUsageInWatt((int)item.EnergyUsage, item.Interval.Minutes);
            LabArea = item.Lab.Area ?? 0;
        }

        LabEUCost = _calculator.CalculateEnergyUsageCost(cost, LabEU);
        energyIntensity = _calculator.CalculateEnergyIntensity(LabArea, LabEU);
        Console.WriteLine("eu = " + LabEU + " cost = " + LabEUCost);

        LabEUList.Add(new EnergyComparisonLabTableDTO
        {
            LabLocation = labName,
            TotalEnergyUsage = Math.Round((double)LabEU / 1000, 2),
            EnergyUsageCost = LabEUCost,
            EnergyUsageIntensity = Math.Round((double)energyIntensity / 1000, 2)
        });

        return LabEUList;
    }

    /// <summary>
    /// Retrieve lab energy usage according to the labName, start and end date
    /// </summary>
    /// <param>lab names</param>
    /// <param>start date</param>
    /// <param>end date</param>
    /// <returns>list of EnergyComparisonGraphDTO</returns>
    public List<EnergyComparisonGraphDTO> GetEnergyUsageByLabNameGraph(string labName, DateTime start, DateTime end)
    {
        List<EnergyUsageLog> result = _repository.GetLabEnergyUsageByLabNameAndDate(labName, start, end).Result;
        int LabEU = 0;
        double energyIntensity = 0;
        int LabArea = 0;

        List<EnergyComparisonGraphDTO> LabEUList = new List<EnergyComparisonGraphDTO>();

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

    /// <summary>
    /// Retrieve energy usage benchmark for the lab according to the labName, start and end date
    /// </summary>
    /// <param>list of lab names</param>
    /// <param>start date</param>
    /// <param>end date</param>
    /// <returns>benchmark value</returns>
    public double GetEnergyUsageByLabNameBenchmark(string[] labNames, DateTime start, DateTime end)
    {
        double benchmark = 0;
        foreach (var i in labNames)
        {
            List<EnergyUsageLog> result = _repository.GetLabEnergyUsageByLabNameAndDate(i, start, end).Result;

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

    /// <summary>
    /// Retrieve device energy usage according to the deviceType, start and end date
    /// </summary>
    /// <param>devices type</param>
    /// <param>start date</param>
    /// <param>end date</param>
    /// <returns>list of EnergyComparisonDeviceTableDTO</returns>
    public List<EnergyComparisonDeviceTableDTO> GetEnergyUsageByDeviceType(string deviceType, DateTime start, DateTime end)
    {
        List<EnergyUsageLog> result = _repository.GetDeviceEnergyUsageByDeviceTypeAndDate(deviceType, start, end).Result;
        int DeviceEU = 0;
        double DeviceEUCost = 0;


        List<EnergyComparisonDeviceTableDTO> DeviceEUList = new List<EnergyComparisonDeviceTableDTO>();

        foreach (var item in result)
        {
            DeviceEU += _calculator.CalculateEnergyUsageInWatt((int)item.EnergyUsage, item.Interval.Minutes);
        }

        DeviceEUCost = _calculator.CalculateEnergyUsageCost(cost, DeviceEU);

        //append to list
        DeviceEUList.Add(new EnergyComparisonDeviceTableDTO
        {
            DeviceType = deviceType,
            TotalEnergyUsage = Math.Round((double)DeviceEU / 1000, 2),
            EnergyUsageCost = DeviceEUCost
        });
        Console.WriteLine(DeviceEUList[0].TotalEnergyUsage);

        return DeviceEUList;
    }

    public List<LabEnergyUsageDTO> GetEnergyUsageEnergyIntensitySelectedLab(int labId, DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieve list of device types
    /// </summary>
    /// <returns>array list</returns>
    public List<string> GetAllDeviceType()
    {
        List<Entities.Device> result = _deviceRepository.GetAllDeviceType().Result;
        List<string> deviceType = new List<string>();

        foreach (var item in result)
        {
            deviceType.Add(item.Type);
        }

        return deviceType;

    }

    /// <summary>
    /// Retrieve list of labs location
    /// </summary>
    /// <returns>array list</returns>
    public List<string> GetAllLabLocation()
    {
        List<Entities.Lab> result = _abRepository.GetAllLabLocation().Result;
        List<string> labNames = new List<string>();

        foreach (var item in result)
        {
            labNames.Add(item.LabLocation);
        }

        return labNames;
    }
}
