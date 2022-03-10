using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Constants;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public static class DummyUser
{
    public static readonly ApplicationUser INSTANCE = new ApplicationUser() {
        FirstName = "Carlos",
        LastName = "Eggsampler",
        UserName = "PepsiLover69"
    };
}
