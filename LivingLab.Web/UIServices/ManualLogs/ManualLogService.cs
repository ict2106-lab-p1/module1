using AutoMapper;

using LivingLab.Core.Constants;
using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Core.Models;
using LivingLab.Web.Models.ViewModels;

namespace LivingLab.Web.UIServices.ManualLogs;

public class ManualLogService : IManualLogService
{
    private readonly IMapper _mapper;
    private readonly IEnergyUsageLogCsvParser _csvParser;
    private readonly IEnergyUsageRepository _repository;
    
    public ManualLogService(IMapper mapper, IEnergyUsageLogCsvParser csvParser, IEnergyUsageRepository repository)
    {
        _mapper = mapper;
        _csvParser = csvParser;
        _repository = repository;
    }
    
    public List<LogItemViewModel> UploadLogs(IFormFile file)
    {
        var logs = _csvParser.Parse(file).ToList();
        return _mapper.Map<List<EnergyUsageCsvModel>, List<LogItemViewModel>>(logs);
    }

    public async Task SaveLogs(List<LogItemViewModel> logs)
    {
        
        var data = _mapper.Map<List<LogItemViewModel>, List<EnergyUsageLog>>(logs);
        // var loggedUser = await _userManager.GetUserAsync(User);
        var loggedUser = DummyUser.INSTANCE;
        await _repository.BulkInsertAsync(data);
        // await _repository.BulkInsertAsyncByUser(data, loggedUser);
    }
}
