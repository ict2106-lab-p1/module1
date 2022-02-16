using System.Diagnostics;

using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
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
    // TODO: Add dependency injection for service/repository
    private readonly IEnergyUsageRepository _repository;

    public ManualLogsController(IMapper mapper, ILogger<ManualLogsController> logger, IEnergyUsageLogCsvParser csvParser, IEnergyUsageRepository repository)
    {
        _mapper = mapper;
        _logger = logger;
        _csvParser = csvParser;
        _repository = repository;
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
        try
        {
            var logs = _csvParser.Parse(file).ToList();
            var logItemsViewModel = _mapper.Map<List<EnergyUsageCsvModel>, List<LogItemViewModel>>(logs);
            return View(nameof(FileUpload), logItemsViewModel);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return View(nameof(FileUpload));
        }
    }

    [HttpPost]
    public async Task<IActionResult> Save(List<LogItemViewModel> logs)
    {
        try
        {
            var data = _mapper.Map<List<LogItemViewModel>, List<EnergyUsageLog>>(logs);
            await _repository.BulkInsertAsync(data);
            
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return Error();
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
