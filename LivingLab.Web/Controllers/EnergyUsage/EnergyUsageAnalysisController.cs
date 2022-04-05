using System.Diagnostics;

using LivingLab.Core.Repositories.EnergyUsage;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.EnergyUsage;
using LivingLab.Web.UIServices.EnergyUsage;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.EnergyUsage;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
[Authorize(Roles = "Labtech")]
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
        return View(GetData());
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
        byte [] content =  _analysisService.Export(GetData().DeviceEUList);
        return File(content, "text/csv", "Device Energy Usage.csv");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

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
    

    public EnergyUsageAnalysisViewModel GetData() {
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




