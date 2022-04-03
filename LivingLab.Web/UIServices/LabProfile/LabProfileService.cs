using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.Models.ViewModels.UserManagement;
using LivingLab.Web.UIServices.LabProfile;

namespace LivingLab.Web.UIServices.LabProfile;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileService : ILabProfileService
{
    private readonly  IMapper _mapper;
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


    public async Task<Lab?> GetLabProfileDetails(string labLocation)
    {
        return await _labProfileDomainService.GetLabProfileDetails(labLocation);
    }

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

    public async Task<List<string>> ViewDeviceType(string labLocation)
    {
        var listOfDevices = await _deviceDomainService.GetDevicesForLabProfile(labLocation);
        List<string> deviceNames = new List<string>();
        foreach (var items in listOfDevices)
        {
            deviceNames.Add(items.Name);
        }
        return deviceNames;
    }

    public async Task<List<string>> ViewAccessoryType(string labLocation)
    {
        var listOfAccessories = await _accessoryDomainService.GetAccessoriesForLabProfile(labLocation);
        List<string> accessoriesName = new List<string>();
        foreach (var items in listOfAccessories)
        {
            accessoriesName.Add(items.Name);
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
