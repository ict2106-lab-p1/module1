using LivingLab.Web.Models.ViewModels.UserManagement;

namespace LivingLab.Web.UIServices.UserManagement;

public interface IUserManagementService
{
    Task<ViewUserManagementViewModel> GetAllAccounts();
    Task<UserManagementViewModel> ViewUserDetails(string id);
    Task<UserManagementViewModel> EditAccount(UserManagementViewModel userViewModel);
    Task<UserManagementViewModel> DeleteAccount(UserManagementViewModel userViewModel);

}
