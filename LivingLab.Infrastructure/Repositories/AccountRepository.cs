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
    public async Task<ApplicationUser> GetAccountDetails(string id)
    {
        ApplicationUser user = (await _context.Users.SingleOrDefaultAsync(d => d.Id == id))!;
        return user;
        // return await _context.Set<ApplicationUser>().ToListAsync();
    }

    /*Get the account by ID*/
    public async Task<ApplicationUser?> GetAccountById(string id)
    {
        return await _context.Set<ApplicationUser>().FindAsync(id);
    }

    /*Add the account into DB*/
    public async Task<ApplicationUser?> AddAccount(ApplicationUser user)
    {
        ApplicationUser currentUser = (await _context.Users.SingleOrDefaultAsync(d => d.Id == user.Id))!;
        currentUser.Email = user.Email;
        currentUser.UserFaculty  = user.UserFaculty;
        currentUser.LabAccesses  = user.LabAccesses;
        await _context.SaveChangesAsync();       
        return user;
        // await _context.AddAsync(user);
        // return user;
    }
    public async Task<ApplicationUser> DeleteAccount(ApplicationUser deleteUser)
    {
        ApplicationUser currentUser = (await _context.Users.SingleOrDefaultAsync(d => d.Id == deleteUser.Id))!;
        _context.Users.Remove(currentUser);
        await _context.SaveChangesAsync();
        return deleteUser;    
    }
}
