using ZooManager.Domain.ValueObjects.FeedingScheduleValueObjects;

namespace ZooManager.Domain.Entities;

public class FeedingSchedule
{
    public FeedingScheduleId Id { get; }
    public Animal Animal { get; }
    public FoodType FoodType { get; }
    public FeedingTime FeedingTime { get; set; }
    public FeedingState FeedingState { get; set; }

    public FeedingSchedule(Animal animal, FoodType foodType, FeedingTime? feedingTime)
    {
        Id = new FeedingScheduleId();
        Animal = animal ?? throw new ArgumentNullException(nameof(animal), "Animal cannot be null.");
        FoodType = foodType;
        FeedingTime = feedingTime ?? throw new ArgumentNullException(nameof(feedingTime), "Feeding time cannot be null.");
        FeedingState = FeedingState.Hungry;
    }
    
    public void ChangeFeedingTime(FeedingTime newFeedingTime)
    {
        FeedingTime = newFeedingTime ?? throw new ArgumentNullException(nameof(newFeedingTime), "New feeding time cannot be null.");
    }

    public void CheckFeeding()
    {
        FeedingState = FeedingState.Fed;
    }
}