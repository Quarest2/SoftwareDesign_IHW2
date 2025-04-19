using ZooManager.Domain.Entities;
using ZooManager.Domain.Interfaces;
using ZooManager.Domain.ValueObjects.EnclosureValueObjects;

namespace ZooManager.Infrastructure;

public class InMemoryEnclosureStorage : IEnclosureStorage
{
    public InMemoryEnclosureStorage(Dictionary<Guid, Enclosure> enclosures)
    {
        Enclosures = enclosures;
    }

    public Dictionary<Guid, Enclosure> Enclosures { get; set; }
}