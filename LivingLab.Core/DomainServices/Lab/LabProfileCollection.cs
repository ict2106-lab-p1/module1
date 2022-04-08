using LivingLab.Core.Entities.DTO.Device;

namespace LivingLab.Core.DomainServices.Lab;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileCollection : IAbstractLabProfileCollection
{
    private List<Entities.Lab> _labProfileList = new();

    public ILabProfileIterator CreateIterator()
    {
        return new LabProfileIterator(this);
    }
    public int Count
    {
        get { return _labProfileList.Count; }
    }

    public void AddLabProfile(Entities.Lab lab)
    {
        _labProfileList.Add(lab);
    }

    public Entities.Lab GetLabProfile(int index)
    {
        return _labProfileList[index];
    }
}
