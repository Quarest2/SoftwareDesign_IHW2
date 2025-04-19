using ZooManager.Domain.Entities;
using ZooManager.Domain.ValueObjects.EnclosureValueObjects;

namespace ZooManager.Domain.Interfaces;

public interface IEnclosureStorage
{
    public Dictionary<Guid, Enclosure> Enclosures { get; set; }
    
    public Enclosure GetEnclosureById(Guid id)
    {
        return Enclosures[id];
    }
}