using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels.Account;

namespace LivingLab.Web.UIServices.Account;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface IAccountService
{
    Task<ApplicationUser?> NewUser(RegisterViewModel input);
    Task<Boolean> GenerateCodeSMS(ApplicationUser user);
    Task<Boolean> GenerateCodeEmail(ApplicationUser user);
    Task<Boolean> VerifyCode(string userid, int OTP);
    Task UpdateUserSettings(ApplicationUser user);
}
