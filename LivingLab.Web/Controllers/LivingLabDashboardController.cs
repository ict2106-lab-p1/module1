using LivingLab.Web.Controllers.Api;
using LivingLab.Web.UIServices.UserManagement;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LivingLabDashboardController: BaseApiController
{
    private readonly IUserManagementService _accountService;
    public LivingLabDashboardController(IUserManagementService accountService)
    {
        _accountService = accountService;
    }
}
