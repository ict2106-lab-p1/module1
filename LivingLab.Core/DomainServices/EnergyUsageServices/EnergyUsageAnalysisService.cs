using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;

namespace LivingLab.Core.DomainServices.EnergyUsageServices;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class EnergyUsageAnalysisService : IEnergyUsageAnalysisService
{
    private readonly IEnergyUsageRepository _repository;

    private readonly IEnergyUsageCalculationService _calculator = new EnergyUsageCalculationService();

    private double cost = 0.2544;

    public EnergyUsageAnalysisService(IEnergyUsageRepository repository)
    {
        _repository = repository;
    }

    public byte[] Export() 
    {
        throw new NotImplementedException();
    }
    public List<DeviceEnergyUsageDTO> GetDeviceEnergyUsageByDate(DateTime start, DateTime end) 
    {
        List<EnergyUsageLog> result = _repository.GetDeviceEnergyUsageByDateTime(start,end).Result;
        //temporary list to store data
        List<string> uniqueDevice = new List<string>();
        List<int> DeviceEU = new List<int>();
        List<int> DeviceUsageTime = new List<int>();
        List<string> DeviceType = new List<string>();
        List<int> DeviceEUPerHour = new List<int>();
        List<double> DeviceEUCost = new List<double>();
        List<DeviceEnergyUsageDTO> DeviceEUList = new List<DeviceEnergyUsageDTO>();

        // get the unique devices in the log and ensure same number of element in each list
        foreach (var item in result)
        {
            if (!uniqueDevice.Contains(item.Device.SerialNo))
            {
                uniqueDevice.Add(item.Device.SerialNo);
                DeviceEU.Add(0);
                DeviceUsageTime.Add(0);
                DeviceType.Add(item.Device.Name);
            }
        }

        // add to total EU of a device if logs are from same device
        foreach (var item in result)
        {
            for (int i = 0; i < uniqueDevice.Count; i++)
            {
                if (item.Device.SerialNo == uniqueDevice[i])
                {
                    DeviceEU[i] += (int)item.EnergyUsage;
                    DeviceUsageTime[i] += item.Interval.Minutes;
                }
            }
            
        }

        // calculate the cost and EU/hour
        for (int i = 0; i < uniqueDevice.Count; i++)
        {
            DeviceEUPerHour.Add(_calculator.CalculateEnergyUsagePerHour(DeviceEU[i],DeviceUsageTime[i]));
            DeviceEUCost.Add(_calculator.CalculateEnergyUsageCost(cost,DeviceEU[i],DeviceUsageTime[i]));
        }

        // append the list of data to DeviceEnergyUsageDTO
        for (int i = 0; i < uniqueDevice.Count; i++)
        {
            DeviceEUList.Add(new DeviceEnergyUsageDTO{
                DeviceSerialNo = uniqueDevice[i],
                DeviceType = DeviceType[i],
                TotalEnergyUsage = DeviceEU[i],
                EnergyUsageCost = DeviceEUCost[i],
                EnergyUsagePerHour = DeviceEUPerHour[i]
                });

        }

        return DeviceEUList;
    }
    public List<LabEnergyUsageDTO> GetLabEnergyUsageByDate(DateTime start, DateTime end) 
    {
        // missing of lab area, commenting this part to ensure no error


        // List<EnergyUsageLog> result = _repository.GetDeviceEnergyUsageByDateTime(start,end).Result;
        // List<string> uniqueLab = new List<string>();
        // List<int> LabEU = new List<int>();
        // List<int> EnergyUsageTime = new List<int>();
        // List<int> LabEUPerHour = new List<int>();
        // List<double> LabEUCost = new List<double>();
        // List<double> LabEUIntensity = new List<double>();
        // List<int> LabArea = new List<int>();

        // /*
        // * get the unique lab into a list
        // */
        // foreach (var item in result)
        // {
        //     if (!uniqueLab.Contains(item.Lab.LabLocation))
        //     {
        //         uniqueLab.Add(item.Lab.LabLocation);
        //         LabEU.Add(0);
        //         EnergyUsageTime.Add(0);
        //         // LabArea.Add(item.Lab.Capacity)
        //     }
        // }

        // /*
        // * get the unique lab into a list
        // */
        // foreach (var item in result)
        // {
        //     for (int i = 0; i < uniqueLab.Count; i++)
        //     {
        //         if (item.Lab.LabLocation == uniqueLab[i])
        //         {
        //             LabEU[i] += (int)item.EnergyUsage;
        //             EnergyUsageTime[i] += item.Interval.Minutes;
        //         }
        //     }
        // }

        // /*
        // * get the unique lab into a list
        // */
        // for (int i = 0; i < uniqueLab.Count; i++)
        // {
        //     LabEUPerHour.Add(_calculator.CalculateEnergyUsagePerHour(LabEU[i],EnergyUsageTime[i]));
        //     LabEUCost.Add(_calculator.CalculateEnergyUsageCost(cost,LabEU[i],EnergyUsageTime[i]));
        //     // LabEUIntensity.Add(_calculator.CalculateEnergyIntensity())
        // }
        

        
        throw new NotImplementedException();

    }
    // joey
    public List<TopSevenLabEnergyUsageDTO> GetTopSevenLabEnergyUsage(DateTime start, DateTime end) 
    {
        throw new NotImplementedException();
    }
    public List<MonthlyEnergyUsageDTO> GetEnergyUsageTrendAllLab(DateTime start, DateTime end) 
    {
        throw new NotImplementedException();
    }
    public List<IndividualLabMonthlyEnergyUsageDTO> GetEnergyUsageTrendSelectedLab(DateTime start, DateTime end, int labId)
    {
        throw new NotImplementedException();
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

    public List<EnergyUsageLog> test(DateTime start, DateTime end) 
    {

        List<EnergyUsageLog> result = _repository.GetDeviceEnergyUsageByDateTime(start,end).Result;
        // Console.WriteLine(result);

        // List<string> uniqueDevice = new List<string>();
        // List<int> DeviceEU = new List<int>();
        // List<int> DeviceUsageTime = new List<int>();
        // List<string> DeviceType = new List<string>();
        // List<int> DeviceEUPerHour = new List<int>();
        // List<double> DeviceEUCost = new List<double>();
        // List<DeviceEnergyUsageDTO> DeviceEUList = new List<DeviceEnergyUsageDTO>();
        // foreach (var item in result)
        // {
        //     if (uniqueDevice.Contains(item.Device.SerialNo))
        //     {
        //         uniqueDevice.Add(item.Device.SerialNo);
        //         DeviceEU.Add(0);
        //         DeviceUsageTime.Add(0);
        //         DeviceType.Add(item.Device.Name);
        //     }
        // }
        // foreach (var item in result)
        // {
        //     for (int i = 0; i < uniqueDevice.Count; i++)
        //     {
        //         if (item.Device.SerialNo == uniqueDevice[i])
        //         {
        //             DeviceEU[i] += (int)item.EnergyUsage;
        //             DeviceUsageTime[i] += item.Interval.Minutes;
        //         }
        //     }
            
        // }

        // for (int i = 0; i < uniqueDevice.Count; i++)
        // {
        //     DeviceEUPerHour.Add(_calculator.CalculateEnergyUsagePerHour(DeviceEU[i],DeviceUsageTime[i]));
        //     DeviceEUCost.Add(_calculator.CalculateEnergyUsageCost(cost,DeviceEU[i],DeviceUsageTime[i]));
        // }

        // for (int i = 0; i < uniqueDevice.Count; i++)
        // {
        //     DeviceEUList.Add(new DeviceEnergyUsageDTO{
        //         DeviceSerialNo = uniqueDevice[i],
        //         DeviceType = DeviceType[i],
        //         TotalEnergyUsage = DeviceEU[i],
        //         EnergyUsageCost = DeviceEUCost[i],
        //         EnergyUsagePerHour = DeviceEUPerHour[i]
        //         });

        // }





        return result;
    }
}