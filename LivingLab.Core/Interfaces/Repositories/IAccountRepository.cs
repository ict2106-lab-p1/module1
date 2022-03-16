using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Interfaces.Repositories;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface IAccountRepository : IRepository<User>
{
    Task<List<ViewAccountsDTO>> GetAllAccount();
    // Task<ApplicationUser?> GetAccount(string userId);
    // Task<ApplicationUser?> AddAccount(ApplicationUser user);
    // Task<int> DeleteAccount(string userId);
}
