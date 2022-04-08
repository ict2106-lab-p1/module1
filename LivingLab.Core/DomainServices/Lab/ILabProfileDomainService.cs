namespace LivingLab.Core.DomainServices.Lab;
/// <summary>
/// Interfaces for the domain services should
/// belong in this directory. Consist of Interfaces for lab profile domain service.
/// </summary>
/// 
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabProfileDomainService
{
    Task<LabProfileCollection> ViewLabs();
    Task<Entities.Lab?> NewLab(Entities.Lab labinput);
    Task<Entities.Lab> GetLabProfileDetails(string labLocation);
}
