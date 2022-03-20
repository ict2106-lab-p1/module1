using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;

using Microsoft.Extensions.Logging;

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
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger _logger;
    
    public AccountDomainService(IAccountRepository accountRepository, ILogger<AccountDomainService> logger)
    {
        _accountRepository = accountRepository;
        _logger = logger;
    }

    public async Task<ApplicationUser?> GetUser(string id)
    {
        return await _accountRepository.GetAccountById(id);
    }

    public async Task<ApplicationUser?> UpdateUser(ApplicationUser user)
    {
        return await _accountRepository.UpdateAsync(user);
    }

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
    }

    public async Task<bool> VerifyCode(string userid, int otpCode)
    {
        var result = await _accountRepository.GetAccountById(userid);
        if (result != null && result.SMSExpiry > DateTime.Now)
        {
            if (result.OTP == otpCode)
            {
                _logger.LogInformation("HENRY Same OTP");
                return true;
            }
        }

        return false;
    }

    public async Task<ApplicationUser?> Save(ApplicationUser user)
    {
        return await _accountRepository.AddAccount(user);
    }
}
