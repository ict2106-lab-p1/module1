using System.Diagnostics;
using System.Data;
using System.Text;

using LivingLab.Core.Models;

using Microsoft.AspNetCore.Mvc;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Entities;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.UIServices.EnergyUsageAnalysisServices;


namespace LivingLab.Web.Controllers;

public class EnergyUsageAnalysisController : Controller
{
    private readonly ILogger<EnergyUsageAnalysisController> _logger;
    private readonly IEnergyUsageRepository _repository;
    private readonly IExportToCSVService _exportService;
    public EnergyUsageAnalysisController(ILogger<EnergyUsageAnalysisController> logger, IEnergyUsageRepository repository, IExportToCSVService exportService)
    {
        _logger = logger;
        _repository = repository;
        _exportService = exportService;
    }

    public IActionResult Index()
    {
        // List<Log> Logs = logList();
        List<DeviceEnergyUsageModel> Logs = DeviceEUList();
        ViewBag.Logs = Logs;
        // GetAll();
        return View(Logs);
    }
    
    [HttpGet]
    public IActionResult Export()
    {
        List<DeviceEnergyUsageModel> Logs = DeviceEUList();
        byte [] content =  _exportService.Export(Logs);
        return File(content, "text/csv", "Device Energy Usage.csv");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public struct Log{
        public Log (String DeviceserialNo, String Devicetype, int Totalenergyusage, int Energyusageperhour, double Energyusagecost) {
            DeviceSerialNo = DeviceserialNo;
            DeviceType = Devicetype;
            TotalEnergyUsage = Totalenergyusage;
            EnergyUsagePerHour = Energyusageperhour;
            EnergyUsageCost = Energyusagecost;
        } 
        public String DeviceSerialNo { get; }
        public String DeviceType { get; }
        public int TotalEnergyUsage { get; }
        public int EnergyUsagePerHour { get; }
        public double EnergyUsageCost { get; }
    }

    public List<Log> logList() {
        List<Log> Logs = new List<Log>();
        Logs.Add(new Log("Sensor-12120","Sensor",234,112,23.21));
        Logs.Add(new Log("Actuator-0881","Actuator",121,231,13.45));
        Logs.Add(new Log("Robot-73","Robot",691,122,83.45));

        return Logs;
    }

    public List<DeviceEnergyUsageModel> DeviceEUList() {
        var Logs = new List<DeviceEnergyUsageModel>(){
            new DeviceEnergyUsageModel{DeviceSerialNo="Sensor-12120",DeviceType="Sensor",TotalEnergyUsage=234,EnergyUsagePerHour=112,EnergyUsageCost=23.21},
            new DeviceEnergyUsageModel{DeviceSerialNo="Actuator-0881",DeviceType="Actuator",TotalEnergyUsage=121,EnergyUsagePerHour=23,EnergyUsageCost=12.21},
            new DeviceEnergyUsageModel{DeviceSerialNo="Robot-73",DeviceType="Robot",TotalEnergyUsage=671,EnergyUsagePerHour=211,EnergyUsageCost=72.45}
        };
        return Logs;
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

    public List<int> FindAllUniqueID (List<EnergyUsageLog> Records) {
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
    public double ConvertTimeToHour(int TimeInMinute) {
        return (double)TimeInMinute / (double)60;
    }
    // calculate energy usage per hour
    public double? CalculateEUPerHour (double? TotalEU, int? TotalEUTime) {
        double? hour = (double)TotalEUTime / (double)60;
        double? EUPerHour = TotalEU / hour;
        return (int)EUPerHour;
    }

    // calculate total energy usage cost
    public double CalculateEUCost(double cost, int TotalEU, double TotalEUTime) {
        double Total = Math.Round((cost * (double)TotalEU * TotalEUTime),2);
        return Total;
    }




} 






