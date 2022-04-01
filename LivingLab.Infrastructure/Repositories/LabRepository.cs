using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

public class LabRepository : Repository<Lab>, ILabRepository
{
    private readonly ApplicationDbContext _context;

    public LabRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Lab>> GetAllLabs()
    {
        var labs = await _context.Labs.ToListAsync();
        return labs;
    }

    #region Added by P1-1
    public Task SetLabEnergyBenchmark(int labId, double energyBenchmark)
    {
        var lab = _context.Labs.FirstOrDefault(l => l.LabId == labId);
        if (lab != null)
        {
            lab.EnergyUsageBenchmark = energyBenchmark;
            _context.Labs.Update(lab);
        }
        return _context.SaveChangesAsync();
    }

    public Task<double> GetLabEnergyBenchmark(int labId)
    {
        var lab = _context.Labs.FirstOrDefault(l => l.LabId == labId);
        return Task.FromResult(lab != null ? lab.EnergyUsageBenchmark!.Value : 0.0);
    }
    #endregion
}
