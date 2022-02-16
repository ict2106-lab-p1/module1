using System.Diagnostics;

using AutoMapper;

using LivingLab.Core.Interfaces.Services;
using LivingLab.Core.Models;
using LivingLab.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;

public class ManualLogsController : Controller
{
    private readonly IMapper _mapper;
    private readonly ILogger<ManualLogsController> _logger;
    private readonly IEnergyUsageLogCsvParser _csvParser;

    public ManualLogsController(IMapper mapper, ILogger<ManualLogsController> logger, IEnergyUsageLogCsvParser csvParser)
    {
        _mapper = mapper;
        _logger = logger;
        _csvParser = csvParser;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult FileUpload()
    {
        return View();
    }

    public IActionResult ManualLogUpload()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Upload(IFormFile file)
    {
        var logs = _csvParser.Parse(file).ToList();
        var logItemsViewModel = _mapper.Map<List<EnergyUsageCsvModel>, List<LogItemViewModel>>(logs);
        return View(nameof(FileUpload), logItemsViewModel);
    }

    [HttpPost]
    public IActionResult Save(List<LogItemViewModel> logs)
    {
        // TODO: Save to database
        return Ok();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
