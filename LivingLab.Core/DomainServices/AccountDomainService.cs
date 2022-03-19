using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;

namespace LivingLab.Core.DomainServices;
/// <summary>
/// Domain service implementations belongs here.
/// Domain service are classes that are responsible for business logic.
/// </summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class AccountDomainService: IAccountDomainService
{
    public readonly IAccountRepository _accountRepository;
    
    //initialise repository 
    public AccountDomainService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public Task<List<ApplicationUser>> ViewAccounts()
    {
        return _accountRepository.GetAllAccount();
    } 
 
    
    public Task<ApplicationUser> ViewAccountDetails(string id)
    {
        return _accountRepository.GetAccountDetails(id);
    }


    public Task<ApplicationUser> EditAccount(ApplicationUser editAccount)
    {
        return _accountRepository.EditUserDetail(editAccount);
    } 
    public Task<ApplicationUser> DeleteAccount(ApplicationUser deletedUser)
    {
        return _accountRepository.DeleteAccount(deletedUser);
    } 
}
