using LivingLab.Web.Controllers.Api;
using LivingLab.Web.UIServices.Account;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabBookingController: Controller
{
    private readonly IAccountService _accountService;
    public LabBookingController(IAccountService accountService)
    {
        _accountService = accountService;
    }
}
