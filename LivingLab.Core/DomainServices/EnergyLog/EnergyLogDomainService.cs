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

    /// <summary>
    /// Logs energy usage for a device and check the energy threshold.
    /// Send notifications if the threshold is exceeded.
    /// </summary>
    /// <param name="log">energy usage log</param>
    /// <returns>EnergyUsageLog</returns>
    public async Task<EnergyUsageLog> Log(EnergyUsageLog log)
    {
        var device = _deviceRepository.GetDeviceBySerialNo(log.Device.SerialNo).Result;
        Console.WriteLine($"DEVICE ID: {device.Id}");
        var lab = await _labRepository.GetLabByLocation(log.Lab.LabLocation);
        log.Device = device;
        log.Lab = lab;

        var labTech = await _accountRepository.GetAccountById(log.Lab.LabInCharge);
        var notificationSetting = labTech.PreferredNotification;

        if (ExceedThreshold(device.Id, log.EnergyUsage.GetValueOrDefault()))
        {
            Notify(notificationSetting, device.Id, device.Threshold);
        }

        return _energyUsageRepository.AddAsync(log).Result;
    }

    /// <summary>
    /// Retrieves latest energy usage logs.
    /// </summary>
    /// <param name="size">Number of logs to retrieve</param>
    /// <returns>List of EnergyUsageLog</returns>
    public Task<List<EnergyUsageLog>> GetLogs(int size)
    {
        return _energyUsageRepository.GetLatestLogs(size);
    }

    /// <summary>
    /// Checks if the energy usage is above the threshold.
    /// </summary>
    /// <param name="deviceId">Device Id</param>
    /// <param name="currentEnergyUsage">Device current energy usage</param>
    /// <returns>True of above threshold, false otherwise</returns>
    public bool ExceedThreshold(int deviceId, double currentEnergyUsage)
    {
        var thresholdSet = _deviceRepository.GetDeviceDetails(deviceId).Result.Threshold;
        return currentEnergyUsage > thresholdSet;
    }

    /// <summary>
    /// Calls the notifier factory to send notifications.
    /// </summary>
    /// <param name="preference">Notification preference</param>
    /// <param name="deviceId">Device Id</param>
    /// <param name="threshold">Threshold limit</param>
    private void Notify(NotificationType preference, int deviceId, double? threshold)
    {
        var message = $"Device ID {deviceId} has exceeded the set threshold of {threshold}.";
        _notifierFactory.CreateNotifier(preference).Notify(message);
    }
}
