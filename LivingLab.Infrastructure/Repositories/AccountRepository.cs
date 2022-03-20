using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class AccountRepository : Repository<ApplicationUser>, IAccountRepository
{
    private readonly ApplicationDbContext _context;

    public AccountRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<ApplicationUser>?> GetAllAccount()
    {
        return await _context.Set<ApplicationUser>().ToListAsync();
    }

    //TODO: Implement a status model return Object, status
    public async Task<ApplicationUser?> GetAccountById(string id)
    {
        return await _context.Set<ApplicationUser>().FindAsync(id);
    }

    public async Task<ApplicationUser?> AddAccount(ApplicationUser user)
    {
        await _context.AddAsync(user);
        return user;
    }

    public async Task<int> DeleteAccount(string userId)
    {
        throw new NotImplementedException();
    }
}
