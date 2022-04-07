using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageBuilder;

namespace LivingLab.Core.DomainServices.Equipment.Device;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class DeviceDirector
{
    private IEnergyUsageBuilder? _builder;

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
