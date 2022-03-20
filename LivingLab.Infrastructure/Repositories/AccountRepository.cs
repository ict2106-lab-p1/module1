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
        // retrieve device db together with device type details using include to join entities
        ApplicationUser user = (await _context.Users.SingleOrDefaultAsync(d => d.Id == id))!;
        return user;
    }
    
    public async Task<ApplicationUser> EditUserDetail(ApplicationUser editUser)
    {
        Console.WriteLine("TEST");

        ApplicationUser currentUser = (await _context.Users.SingleOrDefaultAsync(d => d.Id == editUser.Id))!;
        // currentUser.FirstName = editUser.FirstName;
        // currentUser.LastName = editUser.LastName;
        Console.WriteLine("email" + currentUser.Email);
        Console.WriteLine("TESTtest2");

        currentUser.Email = editUser.Email;
        Console.WriteLine("email" + currentUser.Email);
        Console.WriteLine("email" + editUser.Email);

        Console.WriteLine("TEST3");

        // currentUser.UserFaculty  = editUser.UserFaculty;
        // currentUser.LabAccesses  = editUser.LabAccesses;
        // currentUser.PhoneNumber = editUser.PhoneNumber;
        // currentUser.PasswordHash = editUser.PasswordHash;
        await _context.SaveChangesAsync();        
        Console.WriteLine("Edit successful");

            
        return editUser;
    }
    public async Task<ApplicationUser> DeleteAccount(ApplicationUser deleteUser)
    {
        //getting users entity 
        ApplicationUser currentUser = (await _context.Users.SingleOrDefaultAsync(d => d.Id == deleteUser.Id))!;
        _context.Users.Remove(currentUser);
        await _context.SaveChangesAsync();
        Console.WriteLine("Delete successful");
            
        return deleteUser;    
    }
}
