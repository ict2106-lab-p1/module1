using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

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
        throw new NotImplementedException();
    }

    public async Task<ApplicationUser?> GetAccount(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<ApplicationUser?> AddAccount(ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAccount(string userId)
    {
        throw new NotImplementedException();
    }
}
