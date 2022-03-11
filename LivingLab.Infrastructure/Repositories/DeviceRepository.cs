using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

public class DeviceRepository : Repository<Device>, IDeviceRepository
{
    private readonly ApplicationDbContext _context;

    public DeviceRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<List<ViewDeviceTypeDTO>> GetViewDeviceType()
    {
<<<<<<< HEAD
        var deviceGroup = await _context.Devices.GroupBy(t => t.Type).Select(t=> new{Key = t.Key, Count = t.Count()}).ToListAsync();
=======
        var deviceGroup = await _context.Device.GroupBy(t => t.Type).Select(t=> new{Key = t.Key, Count = t.Count()}).ToListAsync();
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
        List<ViewDeviceTypeDTO> deviceTypeDtos = new List<ViewDeviceTypeDTO>();
        foreach (var group in deviceGroup)
        {
            ViewDeviceTypeDTO deviceTypeDto = new ViewDeviceTypeDTO();
            deviceTypeDto.Type = group.Key;
            deviceTypeDto.Quantity = group.Count;
            deviceTypeDtos.Add(deviceTypeDto);
        }
        
        return deviceTypeDtos;
    }

    public async Task<List<Device>> GetAllDevicesByType(string deviceType)
    {
<<<<<<< HEAD
        List<Device> deviceList = await _context.Devices.Where(t => deviceType.Contains(t.Type)).ToListAsync();
=======
        List<Device> deviceList = await _context.Device.Where(t => deviceType.Contains(t.Type)).ToListAsync();
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
        return deviceList;
    }
}
