using LivingLab.Web.Models.DTOs.Todo;
using LivingLab.Web.Models.ViewModels.UserManagement;

namespace LivingLab.Web.UIServices.UserManagement;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface IUserManagementService
{
    Task<ViewUserManagementViewModel> GetAllAccounts();
}
