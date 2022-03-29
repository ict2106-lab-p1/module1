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
public class EnergyUsageComparisonController : Controller
{
    private readonly ILogger<EnergyUsageAnalysisController> _logger;
    private readonly IEnergyUsageRepository _repository;
    private readonly IEnergyUsageComparisonService _comparisonService;
    public EnergyUsageComparisonController(ILogger<EnergyUsageAnalysisController> logger, IEnergyUsageRepository repository, IEnergyUsageComparisonService comparisonService)
    {
        _logger = logger;
        _repository = repository;
        _comparisonService = comparisonService;
    }

    public IActionResult Index()
    {
        return View();
    }

    //need to implement the return type and implementation 
    // public IActionResult GetLabEnergyUsageDetailTable(string listOfLabId, DateTime start, DateTime end)
    // {
    //     return View();
    // }
    //
    // public IActionResult GetLabEnergyUsageDetailGraph(string listOfLabId, DateTime start, DateTime end)
    // {
    //     return View();
    // }
    //
    // public IActionResult GetDeviceEnergy(string listOfDeviceType, DateTime start, DateTime end)
    // {
    //     return View();
    // }
    //
    // public IActionResult GetLabLocationOrDeviceType(string type)
    // {
    //     return View();
    // }
    // end of skeleton code
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
