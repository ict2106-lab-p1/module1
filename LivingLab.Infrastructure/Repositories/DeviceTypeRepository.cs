using LivingLab.Domain.Entities;
using LivingLab.Domain.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

public class DeviceTypeRepository : Repository<DeviceType>, IDeviceTypeRepository
{
    private readonly ApplicationDbContext _context;

    public DeviceTypeRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    //public async Task<List<Device>> GetTodoTitle(int id)
    //{
    //    List<Device> devices = await _context.DeviceType.Include(d => d.Devices).ToListAsync();
    //    return devices;
    //}

}
