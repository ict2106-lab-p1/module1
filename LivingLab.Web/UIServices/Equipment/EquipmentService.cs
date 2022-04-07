using AutoMapper;

using LivingLab.Core.DomainServices.Equipment.Accessory;
using LivingLab.Core.DomainServices.Equipment.Device;
using LivingLab.Web.Models.ViewModels.Accessory;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.Models.ViewModels.Equipment;

namespace LivingLab.Web.UIServices.Equipment;

/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class EquipmentService : IEquipmentService
{
    private readonly IMapper _mapper;
    private readonly IAccessoryDomainService _accessoryDomainService;
    private readonly IDeviceDomainService _deviceDomainService;

    public EquipmentService(IMapper mapper, IAccessoryDomainService accessoryDomainService,
        IDeviceDomainService deviceDomainService)
    {
        _mapper = mapper;
        _accessoryDomainService = accessoryDomainService;
        _deviceDomainService = deviceDomainService;
    }

    /// <summary>
    /// Get all equipment by lab location
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns>EquipmentViewModel</returns>
    public async Task<EquipmentViewModel> ViewEquipment(string labLocation)
    {
        // retrieve all accessory from specific accessory type from db
        List<Core.Entities.Accessory> accessoryList =
            await _accessoryDomainService.GetAllAccessoriesForReview(labLocation);
        // retrieve all devices from specific device type from db
        List<Core.Entities.Device> deviceList =
            await _deviceDomainService.GetAllDevicesForReview(labLocation);
        List<AccessoryViewModel> accessoryViewModelList =
            _mapper.Map<List<Core.Entities.Accessory>, List<AccessoryViewModel>>(accessoryList);
        List<DeviceViewModel> deviceViewModelList =
            _mapper.Map<List<Core.Entities.Device>, List<DeviceViewModel>>(deviceList);
        return new EquipmentViewModel
        {
            AccessoryViewModelList = accessoryViewModelList,
            DeviceViewModelList = deviceViewModelList
        };
    }

    /// <summary>
    /// Update device status when approved/rejected from ReviewEquipment
    /// </summary>
    /// <param name="deviceId"></param>
    /// <param name="deviceReviewStatus"></param>
    public void UpdateDeviceStatus(string deviceId, string deviceReviewStatus)
    {
        _deviceDomainService.UpdateDeviceStatus(deviceId, deviceReviewStatus);
    }

    /// <summary>
    /// Update accessory status when approved/rejected from ReviewEquipment
    /// </summary>
    /// <param name="accessoryId"></param>
    /// <param name="accessoryReviewStatus"></param>
    public void UpdateAccessoryStatus(string accessoryId, string accessoryReviewStatus)
    {
        _accessoryDomainService.UpdateAccessoryStatus(accessoryId, accessoryReviewStatus);
    }
}
