using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;

namespace LivingLab.Core.DomainServices.EnergyUsageServices;
/// <remarks>
/// Author: Team P1-2
/// </remarks>

public class DeviceEU
{
    private List<DeviceEnergyUsageDTO> _parts = new List<DeviceEnergyUsageDTO>();

        public void Add(DeviceEnergyUsageDTO part)
        {
            this._parts.Add(part);
        }

        public List<DeviceEnergyUsageDTO> product()
        {
            return this._parts;
        }
}