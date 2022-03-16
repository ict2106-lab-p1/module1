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
    
    public AccountDomainService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    
    public Task<List<ViewAccountsDTO>> ViewAccounts()
    {
        return _accountRepository.GetAllAccount();
    } 
}
