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

    /*Get the account by ID*/
    public async Task<ApplicationUser?> GetAccountById(string id)
    {
        return await _context.Set<ApplicationUser>().FindAsync(id);
    }

    /*Add the account into DB*/
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
