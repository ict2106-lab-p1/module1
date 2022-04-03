using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsage;
using LivingLab.Core.Repositories.EnergyUsage;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.EnergyUsage;
using LivingLab.Web.UIServices.EnergyUsage;
using LivingLab.Web.UIServices.LabProfile;
using LivingLab.Web.Models.ViewModels.EnergyUsage;

using Microsoft.AspNetCore.Authorization;


namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
[Authorize(Roles = "Admin")]
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
    public async Task<IActionResult> Index(string? LabLocation = "NYP-SR7C")
    {
        // List<Log> Logs = logList();
        // List<DeviceEnergyUsageDTO> Logs = DeviceEUList1();
        // ViewBag.Logs = Logs;
        ViewBag.LabLocation = LabLocation;
        return View(data());
    }

    public IActionResult DMoreData()
    {
        ViewBag.Logs = "-";
        return View();
    }

    public IActionResult LMoreData()
    {
        ViewBag.Logs = "-";
        return View();
    }

    [HttpGet]
    public IActionResult Export()
    {
        byte [] content =  _analysisService.Export(data().DeviceEUList);
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
            new DeviceEnergyUsageDTO{DeviceSerialNo="Sensor-12120",DeviceType="Sensor",TotalEnergyUsage=234,EnergyUsageCost=23.21},
            new DeviceEnergyUsageDTO{DeviceSerialNo="Actuator-0881",DeviceType="Actuator",TotalEnergyUsage=121,EnergyUsageCost=12.21},
            new DeviceEnergyUsageDTO{DeviceSerialNo="Robot-73",DeviceType="Robot",TotalEnergyUsage=671,EnergyUsageCost=72.45}
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
    //
    // [HttpPost]
    // public async Task<IActionResult> ViewUsage([FromBody] EnergyUsageFilterViewModel filter)
    // {
    //     try
    //     {
    //         var model = await _analysisService.GetEnergyUsageTrendSelectedLab(filter);
    //         return model.Lab != null ? Json(model) : NotFound();
    //     }
    //     catch (Exception e)
    //     {
    //         _logger.Log(LogLevel.Error, e.Message);
    //         return NotFound();
    //     }
    // }
    
    [HttpPost]
    public async Task<IActionResult> ViewUsage([FromBody] EnergyUsageFilterViewModel filter)
    {
        try
        {
            var model = await _analysisService.GetEnergyUsageTrendSelectedLab(filter);
            var modelAll = await _analysisService.GetEnergyUsageTrendAllLab(filter);
            EnergyUsageAnalysisGraphViewModel combinedGraphModels = new EnergyUsageAnalysisGraphViewModel()
            {
                SelectedLabEnergyUsage = model,
                AllLabEnergyUsage = modelAll
            };
            return Json(combinedGraphModels);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            return NotFound();
        }
    }

    // [HttpPost]
    // public async Task<IActionResult> ViewUsage([FromBody] EnergyUsageFilterViewModel filter)
    // {
    //     try
    //     {
    //         var modelAll = await _analysisService.GetEnergyUsageTrendAllLab(filter);
    //         return modelAll.Lab != null ? Json(modelAll) : NotFound();
    //     }
    //     catch (Exception e)
    //     {
    //         _logger.Log(LogLevel.Error, e.Message);
    //         return NotFound();
    //     }
    // }
    
    public EnergyUsageAnalysisViewModel data() {
        DateTime start = new DateTime(2015, 12, 25);
        DateTime end = new DateTime(2022, 12, 25);
        var deviceEUList = _analysisService.GetDeviceEnergyUsageByDate(start,end);
        var labEUList = _analysisService.GetLabEnergyUsageByDate(start,end);
        var viewModel = new EnergyUsageAnalysisViewModel {
            DeviceEUList = deviceEUList,
            LabEUList = labEUList
        };
        return viewModel;
    }


    // [HttpGet("EnergyUsageAnalysis/Benchmark/Lab/{labId?}")]
    public async Task<IActionResult> Benchmark(int? labId = 1)
    {
        try
        {
            var benchmark = await _analysisService.GetLabEnergyBenchmark(labId!.Value);
            return benchmark != null ? View(benchmark) : NotFound();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            return Error();
        }
    }
} 






