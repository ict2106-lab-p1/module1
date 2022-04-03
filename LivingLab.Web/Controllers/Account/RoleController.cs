using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;

public class RoleController: Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;
    public  RoleController(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }
}
