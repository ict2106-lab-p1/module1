using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Web.Models.DTOs.Todo;
using LivingLab.Web.Models.ViewModels.UserManagement;

namespace LivingLab.Web.UIServices.UserManagement;
/// <summary>
/// This is a UI-specific service so it belongs in the Web project.
/// It does not contain any business logic and works with UI-specific types (view models and DTOs).
/// </summary>
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

    public async Task<ViewUserManagementViewModel> GetAllAccounts()
    {
        //get account service 
        List<ApplicationUser> viewAccountDtos = await _accountDomainService.ViewAccounts();
        //map viewDeviceTypeDto to deviceTypeViewModel
        List<UserManagementViewModel> allUserList =
            _mapper.Map<List<ApplicationUser>, List<UserManagementViewModel>>(viewAccountDtos);
        ViewUserManagementViewModel accountViewModel = new ViewUserManagementViewModel();
        accountViewModel.userList = allUserList;
        return accountViewModel;
    }
    
    public async Task<UserManagementViewModel> ViewUserDetails(string id)
    {
        ApplicationUser user = await _accountDomainService.ViewAccountDetails(id);
        UserManagementViewModel userVM = _mapper.Map< ApplicationUser, UserManagementViewModel> (user);
        return userVM;
    }

    public async Task<UserManagementViewModel> EditAccount(UserManagementViewModel userViewModel)
    {
        ApplicationUser editAccount = _mapper.Map<UserManagementViewModel, ApplicationUser> (userViewModel);
        await _accountDomainService.EditAccount(editAccount);
        return userViewModel;    
        
    }
    public async Task<UserManagementViewModel> DeleteAccount(UserManagementViewModel userViewModel)
    {
        ApplicationUser deleteAccount = _mapper.Map<UserManagementViewModel, ApplicationUser> (userViewModel);
        await _accountDomainService.DeleteAccount(deleteAccount);
        
        return userViewModel;    
        
    }
}
