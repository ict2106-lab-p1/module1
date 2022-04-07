using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Repositories.Account;
namespace LivingLab.Core.DomainServices.Account;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class AccountDomainService : IAccountDomainService
{
    private readonly IAccountRepository _accountRepository;

    /// <summary>
    /// Initialise services for accountdomain
    /// </summary>
    /// <param name="accountRepository">Call account repository interface</param>
    public AccountDomainService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    /// <summary>
    /// 1. Call on account repository GetAllAccount function
    /// Return list of all users
    /// </summary>
    /// <returns>List of all users</returns>
    public Task<List<ApplicationUser>> ViewAccounts()
    {
        return _accountRepository.GetAllAccount();
    }

    /// <summary>
    /// 1. Call on account repository GetAccountById function
    /// 2. Retrieve information of user by id
    /// </summary>
    /// <param name="id">String GUID of the user</param>
    /// <returns>ApplicationUser object of the user</returns>
    public Task<ApplicationUser> ViewAccountDetails(string id)
    {
        return _accountRepository.GetAccountById(id);
    }

    /// <summary>
    /// 1. Call on account repository EditAccount function
    /// 2. Update user information to database
    /// 3. Return the reflected changes from the database
    /// </summary>
    /// <param name="editAccount">Parse in the ApplicationUser object</param>
    /// <returns>Return updated ApplicationUser object</returns>
    public Task<ApplicationUser> EditAccount(ApplicationUser editAccount)
    {
        return _accountRepository.UpdateAsync(editAccount);
    }

    /// <summary>
    /// 1. Call on account repository DeleteAccount function
    /// 2. Delete respective user from the database
    /// </summary>
    /// <param name="deletedUser">Parse in the ApplicationUser object</param>
    public void DeleteAccount(ApplicationUser deletedUser)
    {
        _accountRepository.DeleteAccount(deletedUser);
    }

    /*Function to update user information one by one*/
    /// <summary>
    /// 1. Call on account repository UpdateAsync function
    /// 2. Update the user information
    /// 3. Return the updated ApplicationUser object
    /// </summary>
    /// <param name="user"></param>
    /// <returns>ApplicationUser object</returns>
    public async Task<ApplicationUser?> UpdateUser(ApplicationUser user)
    {
        return await _accountRepository.UpdateAsync(user);
    }

    /*Generate random OTP for user*/
    /// <summary>
    /// 1. Generate random 6 digit OTP to store into database
    /// 2. Generate 5 minutes timeout for 2FA authentication
    /// 3. Store into database
    /// </summary>
    /// <param name="user">Parse in ApplicationUser object</param>
    /// <returns>Return status if the task pass or failed</returns>
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
        return false;
    }

    /// <summary>
    /// 1. Check if code is outdated
    /// 2. Check if the OTP is match
    /// </summary>
    /// <param name="userid">User's id</param>
    /// <param name="otpCode">User input OTP</param>
    /// <returns>Return status if the task pass or failed</returns>
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
