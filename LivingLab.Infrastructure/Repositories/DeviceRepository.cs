using LivingLab.Domain.Entities;
using LivingLab.Domain.Interfaces.Repositories;
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

    public async Task<List<Device>> GetDeviceWithDeviceType()
    {
        // retrieve device db together with device type details using include to join entities
        List<Device> devices = await _context.Device.Include(d => d.DeviceType).ToListAsync();
        return devices;
    }
    
    public async Task<Device> GetDeviceDetails(int id)
    {
        // retrieve device db together with device type details using include to join entities
        List<Device> devices = await _context.Device.Include(d => d.DeviceType).ToListAsync();
        return devices[id];
    }

}
