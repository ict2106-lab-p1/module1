using AutoMapper;

using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Web.Models.DTOs.Todo;
using LivingLab.Web.UIServices.Todo;

namespace LivingLab.Web.UIServices.Account;
/// <summary>
/// This is a UI-specific service so it belongs in the Web project.
/// It does not contain any business logic and works with UI-specific types (view models and DTOs).
/// </summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class AccountService : IAccountService
{
    private readonly IMapper _mapper;
    private readonly IAccountRepository _accountRepository;
    
    public AccountService(IMapper mapper, IAccountRepository accountRepository)
    {
        _mapper = mapper;
        _accountRepository = accountRepository;
    }

    public async Task<List<ApplicationUser>>  GetAllAccounts()
    {
        var accounts = await _accountRepository.GetAllAccount();
        if (accounts != null)
        {
            return _mapper.Map<List<Core.Entities.Identity.ApplicationUser>, List<ApplicationUser>>(accounts);
        }
        else
        {
            return null;
        }
    }

    public async Task<ApplicationUser> GetAccount(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<ApplicationUser> AddAccount(ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteAccount(string userId)
    {
        throw new NotImplementedException();
    }
}
