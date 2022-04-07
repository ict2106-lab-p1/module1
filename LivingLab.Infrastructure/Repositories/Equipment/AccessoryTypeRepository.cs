using LivingLab.Core.Entities;
using LivingLab.Core.Repositories.Equipment;
using LivingLab.Infrastructure.Data;

namespace LivingLab.Infrastructure.Repositories.Equipment;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryTypeRepository : Repository<AccessoryType>, IAccessoryTypeRepository
{
    private readonly ApplicationDbContext _context;

    public AccessoryTypeRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

}
