using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;

namespace LivingLab.Core.Interfaces.Services;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IDeviceDomainService
{
    Task<List<Device>> ViewDevice(string deviceType);
    Task<List<ViewDeviceTypeDTO>> ViewDeviceType();
}
