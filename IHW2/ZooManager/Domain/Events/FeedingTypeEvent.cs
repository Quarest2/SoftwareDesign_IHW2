using ZooManager.Domain.ValueObjects.AnimalValueObjects;
using ZooManager.Domain.ValueObjects.FeedingScheduleValueObjects;

namespace ZooManager.Domain.Events;

public class FeedingTimeEvent
{
    public Guid AnimalId { get; }
    public DateTime ScheduledTime { get; }
    public FoodType FoodType { get; }

    public FeedingTimeEvent(Guid animalId, DateTime scheduledTime, FoodType foodType)
    {
        AnimalId = animalId;
        ScheduledTime = scheduledTime;
        FoodType = foodType;
    }
}