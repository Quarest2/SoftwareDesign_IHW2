namespace ZooManager.Domain.ValueObjects.EnclosureValueObjects;

public class EnclosureAnimalsCount
{
    public int Count { get; set; }
    
    public EnclosureAnimalsCount(int count)
    {
        if (count < 0)
        {
            throw new ArgumentException("Count cannot be negative.");
        }
        
        Count = count;
    }
}