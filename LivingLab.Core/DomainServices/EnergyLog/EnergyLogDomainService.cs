using LivingLab.Core.DomainServices.Notifications;
using LivingLab.Core.Entities;
using LivingLab.Core.Enums;
using LivingLab.Core.Repositories.Account;
using LivingLab.Core.Repositories.EnergyUsage;
using LivingLab.Core.Repositories.Equipment;
using LivingLab.Core.Repositories.Lab;

namespace LivingLab.Core.DomainServices.EnergyLog;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyLogDomainService : IEnergyLogDomainService
{
    private readonly IEnergyUsageRepository _energyUsageRepository;
    private readonly IDeviceRepository _deviceRepository;
    private readonly ILabProfileRepository _labRepository;
    private readonly NotifierFactory _notifierFactory;
    private readonly IAccountRepository _accountRepository;


    public EnergyLogDomainService(IEnergyUsageRepository energyUsageRepository, IDeviceRepository deviceRepository, 
        ILabProfileRepository labRepository, NotifierFactory notifierFactory, IAccountRepository accountRepository)
    {
        _energyUsageRepository = energyUsageRepository;
        _deviceRepository = deviceRepository;
        _labRepository = labRepository;
        _notifierFactory = notifierFactory;
        _accountRepository = accountRepository;
    }

    public async Task<EnergyUsageLog> Log(EnergyUsageLog log)
    {
        var device = _deviceRepository.GetDeviceBySerialNo(log.Device.SerialNo).Result;
        Console.WriteLine($"DEVICE ID: {device.Id}");
        var lab = await _labRepository.GetLabByLocation(log.Lab.LabLocation);
        log.Device = device;
        log.Lab = lab;
        
        /*
        * Get the details of the Lab Technician in-charge and notification preference
        */
        var labTech = await _accountRepository.GetAccountById(log.Lab.LabInCharge);
        var notificationSetting = labTech.PreferredNotification;

        /*
         * Call Notify() if threshold exceeded
         */
        if (ExceedThreshold(device.Id, log.EnergyUsage.GetValueOrDefault()))
        {
            Notify(notificationSetting, device.Id, device.Threshold);
        }
        
        return _energyUsageRepository.AddAsync(log).Result;
    }

    
    /*
     * Check if the device has exceeded the threshold set
     */
    public bool ExceedThreshold(int deviceId, double currentEnergyUsage)
    {
        var thresholdSet = _deviceRepository.GetDeviceDetails(deviceId).Result.Threshold;
        return (currentEnergyUsage > thresholdSet);
    }
    
    private void Notify(NotificationType preference, int deviceId, double? threshold)
    {
        string message = $"Device ID {deviceId} has exceeded the set threshold of {threshold}.";;
        _notifierFactory.CreateNotifier(preference).Notify(message);
    }
}
