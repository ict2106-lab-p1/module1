using LivingLab.Web.Models.DTOs;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Api;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyLogApiController : BaseApiController
{
    public Task<IActionResult> Log(EnergyUsageDTO usage)
    {
        throw new NotImplementedException();
    }
}
