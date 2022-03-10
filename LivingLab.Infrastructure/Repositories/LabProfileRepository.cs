using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

namespace LivingLab.Infrastructure.Repositories;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileRepository
    : Repository<Lab>, ILabProfileRepository
{
    private readonly ApplicationDbContext _context;

    public LabProfileRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Lab>?> GetAllLabProfile()
    {
        throw new NotImplementedException();
    }

    public async Task<Lab?> AddLabProfile(Lab entry)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteLabProfile(int labId)
    {
        throw new NotImplementedException();
    }
}
