using AutoMapper;

using LivingLab.Core.DomainServices.Equipment.Accessory;
using LivingLab.Core.DomainServices.Equipment.Device;
using LivingLab.Core.DomainServices.Lab;
using LivingLab.Core.Entities;
using LivingLab.Web.Models.ViewModels.LabProfile;

namespace LivingLab.Web.UIServices.LabProfile;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileService : ILabProfileService
{
    private readonly IMapper _mapper;
    private readonly ILabProfileDomainService _labProfileDomainService;
    private readonly IDeviceDomainService _deviceDomainService;
    private readonly IAccessoryDomainService _accessoryDomainService;

    public LabProfileService(ILabProfileDomainService labProfileService, IMapper mapper, IDeviceDomainService deviceDomainService, IAccessoryDomainService accessoryDomainService)
    {
        _labProfileDomainService = labProfileService;
        _mapper = mapper;
        _deviceDomainService = deviceDomainService;
        _accessoryDomainService = accessoryDomainService;
    }

    /// <summary>
    /// Retrieve Individual Lab Profile Details based on lab location 
    /// Calls the GetLabProfileDetails function from
    /// Lab Profile Domain service interface
    /// </summary>
    /// <returns>Lab Profile Details based on lablocation</returns>

    public async Task<Lab?> GetLabProfileDetails(string labLocation)
    {
        return await _labProfileDomainService.GetLabProfileDetails(labLocation);
    }


    /// <summary>
    /// 1. Retrieve lab information such as for all labs
    /// 2. Calls the ViewLab function from Lab Profile Domain service interface
    /// 3. Put the lab information in a list
    /// </summary>
    /// <returns>A list of lab information </returns>
    public async Task<List<LabInformationModel>?> GetAllLabAccounts()
    {
        var listOfLabs = await _labProfileDomainService.ViewLabs();
        List<LabInformationModel> labAccounts = new List<LabInformationModel>();
        foreach (var lab in listOfLabs)
        {
            labAccounts.Add(new LabInformationModel()
            {
                LabId = lab.LabId,
                LabInCharge = lab.LabInCharge,
                LabLocation = lab.LabLocation,
                LabStatus = lab.LabStatus,
                Capacity = lab.Capacity,
                Occupied = lab.Occupied
            });
        }
        return labAccounts;
    }

    /// <summary>
    /// 1. Retrieve available lab devices types for individual lab based on lab location
    /// 2. Calls the GetDevicesForLabProfile function from Device Domain service interface
    /// 3. Put the devices type names in a list
    /// </summary>
    /// <returns>A list of device type names available based on the lab location</returns>

    public async Task<List<string>> ViewDeviceType(string labLocation)
    {
        var listOfDevices = await _deviceDomainService.GetDevicesForLabProfile(labLocation);
        List<string> deviceNames = new List<string>();
        foreach (var items in listOfDevices)
        {
            if (deviceNames.Contains(items.Name) == false)
            {
                deviceNames.Add(items.Name);
            }
        }
        return deviceNames;
    }

    /// <summary>
    /// 1. Retrieve available accessory types for individual lab based on lab location
    /// 2. Calls the GetAccessoriesForLabProfile function from Accessories Domain service interface
    /// 3. Put the accessory type names in a list
    /// </summary>
    /// <returns>A list of accessory type names available based on the lab location</returns>

    public async Task<List<string>> ViewAccessoryType(string labLocation)
    {
        var listOfAccessories = await _accessoryDomainService.GetAccessoriesForLabProfile(labLocation);
        List<string> accessoriesName = new List<string>();
        foreach (var items in listOfAccessories)
        {
            if (accessoriesName.Contains(items.Name) == false)
            {
                accessoriesName.Add(items.Name);

            }
        }
        return accessoriesName;
    }


    /*Create lab profiles by admins*/
    public async Task<Lab?> NewLab(LabRegisterViewModel labinput)
    {
        var labWrapper = new Lab
        {
            LabLocation = labinput.LabLocation,
            LabStatus = labinput.LabStatus,
            LabInCharge = labinput.LabInCharge,
            Area = labinput.Area,
            Capacity = labinput.Capacity,
            Occupied = labinput.Occupied,
            EnergyUsageBenchmark = labinput.EnergyUsageBenchmark
        };
        return await _labProfileDomainService.NewLab(labWrapper);
    }

}
