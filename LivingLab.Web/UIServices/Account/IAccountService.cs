using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.DTOs.Todo;
using LivingLab.Web.Models.ViewModels.LabProfile;
using LivingLab.Web.Models.ViewModels.Login;

namespace LivingLab.Web.UIServices.Account;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface IAccountService
{
    Task<ApplicationUser?> NewUser(RegisterViewModel input);
    Task <Boolean> GenerateCodeSMS(ApplicationUser user);
    Task <Boolean> GenerateCodeEmail(ApplicationUser user);
    Task<Boolean> VerifyCode(string userid, VerifyViewModel viewModel);
    Task UpdateUserSettings(ApplicationUser user);
}
