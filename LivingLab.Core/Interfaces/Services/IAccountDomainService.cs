using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Interfaces.Services;
/// <summary>
/// Interfaces for the domain services should
/// belong in this directory.
/// </summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface IAccountDomainService
{
    Task<List<ApplicationUser>> ViewAccounts();
    Task<ApplicationUser> ViewAccountDetails(string id);

    Task<ApplicationUser> EditAccount(ApplicationUser editAccount);

    Task<ApplicationUser> DeleteAccount(ApplicationUser deletedUser);

    Task<ApplicationUser?> Save(ApplicationUser user);
    
    Task<ApplicationUser?> GetUser(string id);
    
    Task <ApplicationUser?> UpdateUser(ApplicationUser user);
    Task<Boolean> GenerateCode(ApplicationUser user);
    Task<Boolean> VerifyCode(string userid, int OTP);
}
