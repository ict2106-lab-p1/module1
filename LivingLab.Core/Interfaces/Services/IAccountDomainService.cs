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
    Task<ApplicationUser?> GetUser(string id);
    
    Task <ApplicationUser?> UpdateUser(ApplicationUser user);

    Task<Boolean> GenerateCode(ApplicationUser user);

    Task<Boolean> VerifyCode(string userid, int OTP);

}
