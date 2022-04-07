using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Api;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
[ApiController]
[Route("Api/[controller]/[action]")]
public abstract class BaseApiController : Controller
{
}
