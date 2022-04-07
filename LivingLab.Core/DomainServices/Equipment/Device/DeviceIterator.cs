using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.DomainServices.Equipment.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class DeviceIterator : IDeviceIterator
{
    private int _index;
    private DeviceCollection _collection;

    public DeviceIterator(DeviceCollection collection)
    {
        _collection = collection;
    }

    public ViewDeviceTypeDTO First()
    {
        return _collection.GetDevice(0);
    }

    public bool HasNext()
    {
        return _index < _collection.Count;
    }

    public ViewDeviceTypeDTO Next()
    {
        return this.HasNext() ? _collection.GetDevice(_index++) : new ViewDeviceTypeDTO();
    }
}
