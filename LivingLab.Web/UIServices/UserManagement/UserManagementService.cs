using AutoMapper;

using LivingLab.Core.DomainServices.Account;
using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels.UserManagement;

namespace LivingLab.Web.UIServices.UserManagement;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class UserManagementService : IUserManagementService
{
    private readonly IMapper _mapper;
    private readonly IAccountDomainService _accountDomainService;

    public UserManagementService(IMapper mapper, IAccountDomainService accountDomainService)
    {
        _mapper = mapper;
        _accountDomainService = accountDomainService;
    }
    /// <summary>
    /// 1. Call Account domain service to get all accounts
    /// 2. Retrieve user list 
    /// </summary>
    public async Task<ViewUserManagementViewModel> GetAllAccounts()
    {
        List<ApplicationUser> Account = await _accountDomainService.ViewAccounts();
        List<UserManagementViewModel> AccountList =
            _mapper.Map<List<ApplicationUser>, List<UserManagementViewModel>>(Account);
        ViewUserManagementViewModel UserManagementVM = new ViewUserManagementViewModel();
        UserManagementVM.UserList = AccountList;
        return UserManagementVM;
    }
    /// <summary>
    /// 1. Call Account domain service to get account details by Id function
    /// 2. Retrieve user details by Id 
    /// </summary>
    /// <param name="Id">Filter accounts by Id</param>
    /// <returns>UserManagementVM</returns>
    public async Task<UserManagementViewModel> ViewUserDetails(string Id)
    {
        ApplicationUser AccountById = await _accountDomainService.ViewAccountDetails(Id);
        UserManagementViewModel UserManagementVM = _mapper.Map<ApplicationUser, UserManagementViewModel>(AccountById);
        return UserManagementVM;
    }
    /// <summary>
    /// 1. Call Account domain service to get edit account function
    /// 2. Retrieve user details by Id 
    /// </summary>
    /// <param name="UserManagementVM">Edit account with relevant attributes in ViewModel</param>
    /// <returns>UserManagementVM</returns>
    public async Task<UserManagementViewModel> EditAccount(UserManagementViewModel UserManagementVM)
    {
        ApplicationUser EditAccount = _mapper.Map<UserManagementViewModel, ApplicationUser>(UserManagementVM);
        await _accountDomainService.EditAccount(EditAccount);
        return UserManagementVM;

    }

    /// <summary>
    /// 1. Call Account domain service to get delete account function
    /// 2. Retrieve user details by Id 
    /// </summary>
    /// <param name="UserManagementVM">Delete account with relevant attributes in ViewModel</param>
    /// <returns>UserManagementVM</returns>
    public Task<UserManagementViewModel> DeleteAccount(UserManagementViewModel UserManagementVM)
    {
        ApplicationUser DeleteAccount = _mapper.Map<UserManagementViewModel, ApplicationUser>(UserManagementVM);
        _accountDomainService.DeleteAccount(DeleteAccount);
        return Task.FromResult(UserManagementVM);
    }
}
