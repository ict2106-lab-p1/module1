using LivingLab.Web.Controllers.Api;
using LivingLab.Web.UIServices.UserManagement;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabAccessController: Controller
{
    private readonly IUserManagementService _accountService;
    public LabAccessController(IUserManagementService accountService)
    {
        _accountService = accountService;
    }
}
