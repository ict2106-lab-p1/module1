namespace LivingLab.Core.DomainServices.Lab;
/// <summary>
/// Interfaces for the domain services should
/// belong in this directory.
/// </summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabProfileDomainService
{
    Task<List<Entities.Lab>> ViewLabs();
    Task<Entities.Lab> ViewLabDetails(int id);
    Task<Entities.Lab?> NewLab(Entities.Lab labinput);
    Task<Entities.Lab> GetLabProfileDetails(string labLocation);
}
