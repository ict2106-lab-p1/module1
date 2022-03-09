using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Interfaces.Repositories;

public interface IAccountRepository : IRepository<ApplicationUser>
{
    Task<List<ApplicationUser>?> GetAllAccount();
    Task<ApplicationUser?> GetAccount(string userId);
    Task<ApplicationUser?> AddAccount(ApplicationUser user);
    Task<int> DeleteAccount(string userId);
}
