using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Repositories.Account;

using Microsoft.Extensions.Logging;

namespace LivingLab.Core.DomainServices.Account;
/// <summary>
/// Domain service implementations belongs here.
/// Domain service are classes that are responsible for business logic.
/// </summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class AccountDomainService: IAccountDomainService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger _logger;
    
    public AccountDomainService(IAccountRepository accountRepository, ILogger<AccountDomainService> logger)
    {
        _accountRepository = accountRepository;
        _logger = logger;
    }    
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
        return _accountRepository.GetAccountById(id);
    }


    public Task<ApplicationUser> EditAccount(ApplicationUser editAccount)
    {
        return _accountRepository.AddAccount(editAccount);
    } 
    public Task<ApplicationUser> DeleteAccount(ApplicationUser deletedUser)
    {
        return _accountRepository.DeleteAccount(deletedUser);
    }

    /*Function to update user information one by one*/
    public async Task<ApplicationUser?> UpdateUser(ApplicationUser user)
    {
        return await _accountRepository.UpdateAsync(user);
    }

    /*Generate random OTP for user*/
    public async Task<bool> GenerateCode(ApplicationUser user)
    {
        var oldValue = user.OTP;
        Random random = new Random();
        int newCode = random.Next(100000, 999999);

        DateTime newTime = DateTime.Now;
        newTime = newTime.AddMinutes(5);
        user.SMSExpiry = newTime;
        user.OTP = newCode;

        await _accountRepository.UpdateAsync(user);

        if (user.OTP != oldValue)
        {
            return true;
        }
        else
        {
            return false;
        }
        return false;
    }

    /*Verify the OTP with checking of expiry*/
    public async Task<bool> VerifyCode(string userid, int otpCode)
    {
        var result = await _accountRepository.GetAccountById(userid);
        if (result != null && result.SMSExpiry > DateTime.Now)
        {
            if (result.OTP == otpCode)
            {
                //If match returns true
                return true;
            }
        }

        return false;
    }
    
}
