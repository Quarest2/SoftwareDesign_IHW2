namespace ZooManager.Domain.ValueObjects.FeedingScheduleValueObjects;

public class FeedingTime
{
    public TimeOnly Time { get; }

    public FeedingTime(TimeOnly time)
    {
        Time = time;
    }
}