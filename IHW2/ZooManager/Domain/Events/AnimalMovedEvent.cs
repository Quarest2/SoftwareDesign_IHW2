using ZooManager.Domain.ValueObjects.AnimalValueObjects;
using ZooManager.Domain.ValueObjects.EnclosureValueObjects;

namespace ZooManager.Domain.Events;

public class AnimalMovedEvent
{
    public Guid AnimalId { get; }
    public Guid FromEnclosureId { get; }
    public Guid ToEnclosureId { get; }
    public DateTime Timestamp { get; }

    public AnimalMovedEvent(Guid animalId, Guid fromEnclosureId, Guid toEnclosureId)
    {
        AnimalId = animalId;
        FromEnclosureId = fromEnclosureId;
        ToEnclosureId = toEnclosureId;
        Timestamp = DateTime.UtcNow;
    }
}