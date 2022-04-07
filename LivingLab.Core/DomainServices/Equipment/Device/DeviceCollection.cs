using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.DomainServices.Equipment.Device;

/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class DeviceCollection : IAbstractDeviceCollection
{
    private List<ViewDeviceTypeDTO> _deviceDTOList = new();

    public IDeviceIterator CreateIterator()
    {
        return new DeviceIterator(this);
    }
    public int Count
    {
        get { return _deviceDTOList.Count; }
    }

    public void AddDevice(ViewDeviceTypeDTO device)
    {
        _deviceDTOList.Add(device);
    }

    public ViewDeviceTypeDTO GetDevice(int index)
    {
        return _deviceDTOList[index];
    }
}
