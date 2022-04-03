using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;

namespace LivingLab.Core.DomainServices.EnergyUsageLogServices;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyLogDomainService : IEnergyLogDomainService
{
    private readonly IEnergyUsageRepository _energyUsageRepository;
    private readonly IDeviceRepository _deviceRepository;
    private readonly ILabProfileRepository _labRepository;

    public EnergyLogDomainService(IEnergyUsageRepository energyUsageRepository, IDeviceRepository deviceRepository, ILabProfileRepository labRepository)
    {
        _energyUsageRepository = energyUsageRepository;
        _deviceRepository = deviceRepository;
        _labRepository = labRepository;
    }

    public async Task<EnergyUsageLog> Log(EnergyUsageLog log)
    {
        var device = _deviceRepository.GetDeviceBySerialNo(log.Device.SerialNo).Result;
        var lab = await _labRepository.GetLabByLocation(log.Lab.LabLocation);
        log.Device = device;
        log.Lab = lab;
        return _energyUsageRepository.AddAsync(log).Result;
    }

    public Task CheckThreshold(int deviceId)
    {
        throw new NotImplementedException();
    }

    private void Notify()
    {
        throw new NotImplementedException();
    }
}