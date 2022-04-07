using System.Diagnostics;

using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.EnergyUsage;
using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.UIServices.EnergyUsage;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
[Authorize(Roles = "Labtech")]
public class EnergyUsageController : Controller
{
    private readonly IEnergyUsageService _energyUsageService;
    private readonly ILogger<EnergyUsageController> _logger;
    public EnergyUsageController(IEnergyUsageService energyUsageService, ILogger<EnergyUsageController> logger)
    {
        _energyUsageService = energyUsageService;
        _logger = logger;
    }

    /// <summary>
    /// 1. Retrieve the labs and populate
    /// 2. Redirect to Index
    /// </summary>
    /// <returns>list of lab information model</returns>
    public async Task<IActionResult> Index()
    {
        var labs = await _energyUsageService.GetAllLabs();
        var newLabList = new ViewLabProfileViewModel()
        {
            labList = labs
        };
        return View(newLabList.labList);
    }

    /// <summary>
    /// Pass lab ID to the lab view
    /// </summary>
    /// <param name="LabId"></param>
    /// <returns>Redirect to lab</returns>
    public IActionResult Lab(int? LabId = 1)
    {
        ViewBag.LabId = LabId;
        return View();
    }


    /// <summary>
    /// Retrieve the energy lab usage per lab
    /// </summary>
    /// <param name="filter"></param>
    /// <returns>lab model json</returns>
    [HttpPost]
    public async Task<IActionResult> GetLabUsage([FromBody] EnergyUsageFilterViewModel filter)
    {
        try
        {
            var model = await _energyUsageService.GetEnergyUsage(filter);
            return model.Lab != null ? Json(model) : NotFound();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            return NotFound();
        }
    }

    /// <summary>
    /// Get benchmark of a lab's energy usage
    /// </summary>
    /// <param name="labId"></param>
    /// <returns>benchmark model</returns>
    [HttpGet("EnergyUsage/Benchmark/Lab/{labId?}")]
    public async Task<IActionResult> Benchmark(int? labId = 1)
    {
        try
        {
            var benchmark = await _energyUsageService.GetLabEnergyBenchmark(labId!.Value);
            return benchmark != null ? View(benchmark) : NotFound();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            return Error();
        }
    }

    /// <summary>
    /// Set the benchmark for the lab's energy usage
    /// </summary>
    /// <param name="benchmark"></param>
    /// <returns>route to index</returns>
    [HttpPost]
    public async Task<IActionResult> SetBenchmark(EnergyBenchmarkViewModel benchmark)
    {
        try
        {
            await _energyUsageService.SetLabEnergyBenchmark(benchmark);
            return RedirectToAction(nameof(Index), new { labId = benchmark.LabId });
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            return RedirectToAction(nameof(Benchmark));
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
