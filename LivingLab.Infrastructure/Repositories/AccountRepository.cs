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
public class AccountRepository : Repository<User>, IAccountRepository
{
    private readonly ApplicationDbContext _context;

    public AccountRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    
    //Get all user accounts
    public async Task<List<User>> GetAllAccount()
    {
        // var accountGroup = await _context.Users.Include(a => a.Faculty)
        //     .GroupBy(t => t.Faculty!)
        //     .Select(t=> new{Key = t.Key, Count = t.Count()})
        //     .ToListAsync();
        //retrieve users from database
        var accountGroup = await _context.Users.ToListAsync();
        //only call required entity to display table
        // List<ViewAccountsDTO> accountDtos = new List<ViewAccountsDTO>();
        // foreach (var group in accountGroup)
        // {
        //     ViewAccountsDTO accountDto = new ViewAccountsDTO();
        //     accountDto.Faculty = group.Key;
        //     accountDto.Id = group.Count;
        //     accountDtos.Add(accountDto);
        // }
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
    // public async Task<int> DeleteAccount(string userId)
    // {
    //     throw new NotImplementedException();
    // }
}
