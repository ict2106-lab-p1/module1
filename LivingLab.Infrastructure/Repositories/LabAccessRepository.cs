using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

public class LabAccessRepository : Repository<LabAccess>, ILabAccessRepository
{
    private readonly ApplicationDbContext _context;

    public LabAccessRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<LabAccess?> GetInvalidLabAccess(string userId, string initiatorId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<LabAccess>?> GetAllInvalidLabAccess()
    {
        throw new NotImplementedException();
    }

    public async Task<LabAccess?> AddInvalidLabAccess(LabAccess entry)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteInvalidLabAccess(string userId, string labId)
    {
        throw new NotImplementedException();
    }
}
