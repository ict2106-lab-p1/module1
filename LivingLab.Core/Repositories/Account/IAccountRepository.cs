using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Repositories.Account;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface IAccountRepository : IRepository<ApplicationUser>
{
    Task<List<ApplicationUser>?> GetAllAccount();
    Task<ApplicationUser?> GetAccountById(string id);
    Task DeleteAccount(ApplicationUser deleteUser);
}
