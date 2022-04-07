using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.DomainServices.Equipment.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IDeviceIterator
{
    public bool HasNext();
    public ViewDeviceTypeDTO Next();

    public ViewDeviceTypeDTO First();
}
