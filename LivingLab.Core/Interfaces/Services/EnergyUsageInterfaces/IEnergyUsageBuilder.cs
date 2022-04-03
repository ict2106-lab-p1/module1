namespace LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;

/// <remarks>
/// Author: Team P1-2
/// </remarks>
public interface IEnergyUsageBuilder
{
    void BuildDistinctIdentifier ();
    void BuildEUInWatt ();
    void BuildEUCost ();
    void BuildEUList ();
    
}