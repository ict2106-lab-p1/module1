using LivingLab.Core.Entities.Identity;

public static class DummyUser
{
    public static readonly ApplicationUser INSTANCE = new ApplicationUser() {
        FirstName = "Carlos",
        LastName = "Eggsampler",
        UserName = "PepsiLover69"
    };
}