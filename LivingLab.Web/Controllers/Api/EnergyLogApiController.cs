using LivingLab.Web.Models.DTOs;

using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Api;

public class EnergyLogApiController : BaseApiController
{
    public Task<IActionResult> Log(EnergyUsageDTO usage)
    {
        throw new NotImplementedException();
    }
}
