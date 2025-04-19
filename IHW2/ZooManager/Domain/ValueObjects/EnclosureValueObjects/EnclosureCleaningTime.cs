namespace ZooManager.Domain.ValueObjects.EnclosureValueObjects;

public class EnclosureCleaningTime
{
    public DateTime Time { get; }
    
    public EnclosureCleaningTime(DateTime time)
    {
        Time = time;
    }
}