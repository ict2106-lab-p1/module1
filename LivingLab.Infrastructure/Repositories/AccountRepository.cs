using System.Net.Mime;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
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
    
    //Get all user accounts
    public async Task<List<ApplicationUser>> GetAllAccount()
    {
        var accountGroup = await _context.Users.ToListAsync();
        return accountGroup;
    }

    
    // public async Task<ApplicationUser?> GetAccount(string userId)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public async Task<ApplicationUser?> AddAccount(ApplicationUser user)
    // {
    //     throw new NotImplementedException();
    // }
    //
    public async Task<ApplicationUser> DeleteAccount(ApplicationUser deleteUser)
    {
        // retrieve device db together with device type details using include to join entities
        ApplicationUser currentUser = (await _context.Users.SingleOrDefaultAsync(d => d.Id == deleteUser.Id))!;
        _context.Users.Remove(currentUser);
        await _context.SaveChangesAsync();
        Console.WriteLine("Delete Succ");
            
        return deleteUser;    
    }
}
