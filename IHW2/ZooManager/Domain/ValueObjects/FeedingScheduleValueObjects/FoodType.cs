namespace ZooManager.Domain.ValueObjects.FeedingScheduleValueObjects;

public class FoodType
{
    public string Type { get; }

    public FoodType(string type)
    {
        Type = type;
    }
}