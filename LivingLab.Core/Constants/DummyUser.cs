using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Constants;

public static class DummyUser
{
    public static readonly ApplicationUser INSTANCE = new ApplicationUser() {
        FirstName = "Carlos",
        LastName = "Eggsampler",
        UserName = "PepsiLover69"
    };
}