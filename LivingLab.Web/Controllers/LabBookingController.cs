using LivingLab.Web.Controllers.Api;
using LivingLab.Web.UIServices.Account;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabBookingController: BaseApiController
{
    private readonly IAccountService _accountService;
    public LabBookingController(IAccountService accountService)
    {
        _accountService = accountService;
    }
}
