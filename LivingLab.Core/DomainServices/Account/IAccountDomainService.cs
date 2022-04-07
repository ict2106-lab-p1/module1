using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.DomainServices.Account;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface IAccountDomainService
{
    Task<List<ApplicationUser>> ViewAccounts();
    Task<ApplicationUser> ViewAccountDetails(string id);
    Task<ApplicationUser> EditAccount(ApplicationUser editAccount);
    void DeleteAccount(ApplicationUser deletedUser);
    Task<ApplicationUser?> UpdateUser(ApplicationUser user);
    Task<Boolean> GenerateCode(ApplicationUser user);
    Task<Boolean> VerifyCode(string userid, int OTP);
}
