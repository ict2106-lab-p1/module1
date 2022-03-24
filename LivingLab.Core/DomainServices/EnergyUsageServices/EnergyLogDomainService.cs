using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;

namespace LivingLab.Core.DomainServices.EnergyUsageServices;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyLogDomainService : IEnergyLogDomainService
{
    private readonly IEnergyUsageRepository _energyUsageRepository;
    private readonly IDeviceRepository _deviceRepository;
    private readonly ILabRepository _labRepository;
    
    public EnergyLogDomainService(IEnergyUsageRepository energyUsageRepository, IDeviceRepository deviceRepository, ILabRepository labRepository)
    {
        _energyUsageRepository = energyUsageRepository;
        _deviceRepository = deviceRepository;
        _labRepository = labRepository;
    } 
    
    public Task<EnergyUsageLog> Log(EnergyUsageLog log)
    {
        var device = _deviceRepository.GetDeviceBySerialNo(log.Device.SerialNo).Result;
        var lab = _labRepository.GetByIdAsync(log.Lab.LabId).Result;
        log.Device = device;
        log.Lab = lab;
        return _energyUsageRepository.AddAsync(log);
    }
}
