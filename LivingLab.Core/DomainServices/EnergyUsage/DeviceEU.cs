using LivingLab.Core.Entities.DTO.EnergyUsage;

namespace LivingLab.Core.DomainServices.EnergyUsage;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class DeviceEU
{
    private List<DeviceEnergyUsageDTO> _parts = new List<DeviceEnergyUsageDTO>();

    /// <summary>
    /// Add input into list
    /// </summary>
    /// <param name="parts">DeviceEnergyUsageDTO</param>
    public void Add(DeviceEnergyUsageDTO part)
    {
        this._parts.Add(part);
    }

    /// <summary>
    /// return the final product
    /// </summary>
    /// <returns>list of LabEnergyUsageDTO</returns>
    public List<DeviceEnergyUsageDTO> product()
    {
        return this._parts;
    }
}
