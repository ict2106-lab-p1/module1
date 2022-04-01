using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.Interfaces.Repositories;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IDeviceRepository : IRepository<Device>
{
    Task<Device> GetDeviceBySerialNo(string serialNo);
    Task<List<ViewDeviceTypeDTO>> GetViewDeviceType(string labLocation);
    Task<List<Device>> GetAllDevicesByType(string deviceType, string labLocation);
    void UpdateDeviceStatus(string deviceId, string deviceReviewStatus);
    Task<List<Device>> GetAllDevicesForReview(string labLocation);
    Task<Device> GetDeviceDetails(int id);
    Task<List<Device>> GetDevicesForLabProfile(string labLocation);
    Task<Device> GetLastRow();
    Task<Device> AddDevice(Device addedDevice);
    Task<Device> EditDeviceDetails(Device editedDevice);
    Task<Device> DeleteDevice(Device deleteDevice);
}
