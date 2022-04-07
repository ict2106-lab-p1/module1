using System.Diagnostics;

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
    private readonly IEnergyUsageAnalysisUIService _analysisService;

    public EnergyUsageAnalysisController(ILogger<EnergyUsageAnalysisController> logger,
        IEnergyUsageAnalysisUIService analysisService)
    {
        _logger = logger;
        _analysisService = analysisService;
    }

    /// <summary>
    ///     Index page of analysisDomain
    /// </summary>
    /// <returns>view with tables and graphs</returns>
    public IActionResult Index()
    {
        return View(GetData());
    }

    /// <summary>
    ///     Display additonal devices in-detail
    /// </summary>
    /// <returns>view</returns>
    public IActionResult DeviceMoreDetail()
    {
        return View();
    }

    /// <summary>
    ///     Display additonal lab in-detail
    /// </summary>
    /// <returns>view of devices</returns>
    public IActionResult LabMoreDetail()
    {
        return View();
    }

    /// <summary>
    ///     Export the device data in the table
    /// </summary>
    /// <returns>csv file of device energy usage</returns>
    [HttpGet]
    public IActionResult Export()
    {
        var content = _analysisService.Export(GetData().DeviceEUList);
        return File(content, "text/csv", "Device Energy Usage.csv");
    }

    /// <summary>
    ///     Error modal
    /// </summary>
    /// <returns>view with error message</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    /// <summary>
    ///     View the graphs
    /// </summary>
    /// <returns>view selected lab energy usage graph and the all lab energy usage graph</returns>
    [HttpPost]
    public async Task<IActionResult> ViewUsage([FromBody] EnergyUsageFilterViewModel filter)
    {
        try
        {
            var model = await _analysisService.GetEnergyUsageTrendSelectedLab(filter);
            var modelAll = await _analysisService.GetEnergyUsageTrendAllLab(filter);
            var combinedGraphModels = new EnergyUsageAnalysisGraphViewModel
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

    /// <summary>
    ///     Get the data for lab and device
    /// </summary>
    /// <returns>viewmodel with device and lab energy usage data</returns>
    public EnergyUsageAnalysisViewModel GetData()
    {
        var start = new DateTime(2015, 12, 25);
        var end = new DateTime(2022, 12, 25);
        var deviceEUList = _analysisService.GetDeviceEnergyUsageByDate(start, end);
        var labEUList = _analysisService.GetLabEnergyUsageByDate(start, end);
        var viewModel = new EnergyUsageAnalysisViewModel { DeviceEUList = deviceEUList, LabEUList = labEUList };
        return viewModel;
    }

    /// <summary>
    ///     Get benchmark of the energy usage
    /// </summary>
    /// <returns>benchmark value</returns>
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
