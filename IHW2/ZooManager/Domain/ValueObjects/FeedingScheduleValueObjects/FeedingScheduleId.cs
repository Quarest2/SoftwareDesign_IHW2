namespace ZooManager.Domain.ValueObjects.FeedingScheduleValueObjects;

public class FeedingScheduleId
{
    public Guid Id { get; }
    
    public FeedingScheduleId()
    {
        Id = new Guid();
    }
}