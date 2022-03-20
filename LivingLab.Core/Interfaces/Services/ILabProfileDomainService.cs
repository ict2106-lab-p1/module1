using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Services;
/// <summary>
/// Interfaces for the domain services should
/// belong in this directory.
/// </summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabProfileDomainService
{
    Task<List<Lab>> ViewLabs();
    Task<Lab> ViewLabDetails(int id);


}
