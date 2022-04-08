using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.DomainServices.Lab;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileIterator : ILabProfileIterator
{
    private int _index;
    private LabProfileCollection _collection;

    public LabProfileIterator(LabProfileCollection collection)
    {
        _collection = collection;
    }

    public Entities.Lab First()
    {
        return _collection.GetLabProfile(0);
    }

    public bool HasNext()
    {
        return _index < _collection.Count;
    }

    public Entities.Lab Next()
    {
        return this.HasNext() ? _collection.GetLabProfile(_index++) : new Entities.Lab();
    }
}
