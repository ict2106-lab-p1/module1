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
        var deviceGroup = await _context.Device.GroupBy(t => t.Type).Select(t=> new{Key = t.Key, Count = t.Count()}).ToListAsync();
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
        List<Device> deviceList = await _context.Device.Where(t => deviceType.Contains(t.Type)).ToListAsync();
        return deviceList;
    }
}
