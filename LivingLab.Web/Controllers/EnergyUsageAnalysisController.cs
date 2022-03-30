using System.Diagnostics;

using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;

using Microsoft.AspNetCore.Mvc;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Entities;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.UIServices.EnergyUsage;


namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class EnergyUsageAnalysisController : Controller
{
    private readonly ILogger<EnergyUsageAnalysisController> _logger;
    private readonly IEnergyUsageRepository _repository;
    private readonly IEnergyUsageAnalysisUIService _analysisService;
    public EnergyUsageAnalysisController(ILogger<EnergyUsageAnalysisController> logger, IEnergyUsageRepository repository, IEnergyUsageAnalysisUIService analysisService)
    {
        _logger = logger;
        _repository = repository;
        _analysisService = analysisService;
    }

    public IActionResult Index()
    {
        // List<Log> Logs = logList();
        List<DeviceEnergyUsageDTO> Logs = DeviceEUList1();
        ViewBag.Logs = Logs;
        // GetAll();
        return View(Logs);
    }
    
    [HttpGet]
    public IActionResult Export()
    {
        List<DeviceEnergyUsageDTO> Logs = DeviceEUList();
        byte [] content =  _analysisService.Export();
        return File(content, "text/csv", "Device Energy Usage.csv");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public List<DeviceEnergyUsageDTO> DeviceEUList() 
    {
        var Logs = new List<DeviceEnergyUsageDTO>(){
            new DeviceEnergyUsageDTO{DeviceSerialNo="Sensor-12120",DeviceType="Sensor",TotalEnergyUsage=234,EnergyUsagePerHour=112,EnergyUsageCost=23.21},
            new DeviceEnergyUsageDTO{DeviceSerialNo="Actuator-0881",DeviceType="Actuator",TotalEnergyUsage=121,EnergyUsagePerHour=23,EnergyUsageCost=12.21},
            new DeviceEnergyUsageDTO{DeviceSerialNo="Robot-73",DeviceType="Robot",TotalEnergyUsage=671,EnergyUsagePerHour=211,EnergyUsageCost=72.45}
        };
        return Logs;
    }

    public List<DeviceEnergyUsageDTO> DeviceEUList1() 
    {
        DateTime start = new DateTime(2015, 12, 25);
        DateTime end = new DateTime(2022, 12, 25);
        return _analysisService.GetDeviceEnergyUsageByDate(start,end);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var records = _repository.GetAllAsync().Result;
                // var records = DeviceEUList();
        return Ok(records);
    }
    public void GetAlla()
    {
        var records = _repository.GetAllAsync().Result;
        var AllDevices = FindAllUniqueID(records);
        foreach (var item in AllDevices)
        {
            Console.WriteLine(item);
        }
    }

    public List<int> FindAllUniqueID (List<EnergyUsageLog> Records) 
    {
        List<int> IdList = new List<int>();
        foreach (var item in Records)
        {
            if (!IdList.Contains(item.Device.Id))
            {
                IdList.Add(item.Device.Id);
            } 
        }
        return IdList;
    }

    // convert time in minutes to hour
    public double ConvertTimeToHour(int TimeInMinute) 
    {
        return (double)TimeInMinute / (double)60;
    }
    // calculate energy usage per hour
    public double? CalculateEUPerHour (double? TotalEU, int? TotalEUTime) 
    {
        double? hour = (double)TotalEUTime / (double)60;
        double? EUPerHour = TotalEU / hour;
        return (int)EUPerHour;
    }

    // calculate total energy usage cost
    public double CalculateEUCost(double cost, int TotalEU, double TotalEUTime) 
    {
        double Total = Math.Round((cost * (double)TotalEU * TotalEUTime),2);
        return Total;
    }




} 






