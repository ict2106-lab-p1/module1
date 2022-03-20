using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Interfaces.Repositories;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface IAccountRepository : IRepository<ApplicationUser>
{
    Task<List<ApplicationUser>?> GetAllAccount();
    Task<ApplicationUser?> GetAccountById(string id);
    Task<ApplicationUser?> AddAccount(ApplicationUser user);
    Task<int> DeleteAccount(string userId);
    
}
