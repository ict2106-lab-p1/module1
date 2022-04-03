using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using System.Text;

namespace LivingLab.Core.DomainServices.EnergyUsageServices;

public class DeviceDirector
{
    private IEnergyUsageBuilder _builder;
        
    public IEnergyUsageBuilder Builder
    {
        set { _builder = value; } 
    }
    
    // The Director can construct several product variations using the same
    // building steps.
    public void BuildDeviceEU()
    {
        this._builder.BuildDistinctIdentifier();
        this._builder.BuildEUInWatt();
        this._builder.BuildEUCost();
        this._builder.BuildEUList();
    }
}