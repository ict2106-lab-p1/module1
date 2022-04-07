using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Repositories.Account;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories.Account;
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

    /// <summary>
    /// 1. Retrieve list of Accounts
    /// 2. Returns list of all users registered
    /// </summary>
    /// <returns>Return list of all users</returns>
    public async Task<List<ApplicationUser>?> GetAllAccount()
    {
        var AccountGroup = await _context.Users.ToListAsync();
        return AccountGroup;
    }

    /// <summary>
    /// 1. Retrieve user account find by id
    /// 2. Returns list of all users registered
    /// </summary>
    /// <param name="id">String GUID of user</param>
    /// <returns>Return ApplicationUser object</returns>
    public async Task<ApplicationUser?> GetAccountById(string id)
    {
        return await _context.Set<ApplicationUser>().FindAsync(id);
    }

    //// <summary>
    /// 1. Search for user by id
    /// 2. Delete user from database
    /// </summary>
    /// <param name="deleteUser">ApplicationUser of user to be deleted</param>
    public async Task DeleteAccount(ApplicationUser deleteUser)
    {
        ApplicationUser CurrentUser = (await _context.Users.SingleOrDefaultAsync(d => d.Id == deleteUser.Id))!;
        _context.Users.Remove(CurrentUser);
        await _context.SaveChangesAsync();
    }
}
