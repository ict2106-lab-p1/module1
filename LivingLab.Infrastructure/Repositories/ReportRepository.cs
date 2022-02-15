using LivingLab.Domain.Entities;
using LivingLab.Domain.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

public class ReportRepository : Repository<Report>, IReportRepository
{
    private readonly ApplicationDbContext _context;

    public ReportRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    //public async Task<string?> GetTodoTitle(int id)
    //{
    //    var todo = await _context.Todos.FirstOrDefaultAsync(t => t.ID == id);
    //    return todo?.Title;
    //}

}
