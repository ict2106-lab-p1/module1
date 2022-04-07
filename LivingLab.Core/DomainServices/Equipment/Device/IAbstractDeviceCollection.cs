namespace LivingLab.Core.DomainServices.Equipment.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IAbstractDeviceCollection
{
    IDeviceIterator CreateIterator();
}
