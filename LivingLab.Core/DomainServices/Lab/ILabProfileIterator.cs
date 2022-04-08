using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.DomainServices.Lab;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabProfileIterator
{
    public bool HasNext();
    public Entities.Lab Next();

    public Entities.Lab First();
}
